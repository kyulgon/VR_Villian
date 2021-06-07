using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterCtrl_G : MonoBehaviour
{
    public enum MonsterState
    {
        idle,
        trace,
        attack,
        die
    };
    public MonsterState monsterState = MonsterState.idle;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator animator;


    public float traceDist = 10.0f; // ���� �����Ÿ�
    public float attackDist = 15f; // ���� �����Ÿ�
    public ParticleSystem bossAttackEffect; // �������� ����Ʈ

    private bool isDie = false; // ���� ��� ����
    private float attackAmount = 15.0f;

    public float hp = 100.0f;
    private float maxhp = 100f;
    public Slider hpSlider;


    public float timeBetFire = 0.12f; // ź�� �߻� ����
    public float reloadTime = 1.8f; // ������ �ҿ� �ð�
    private float lastFireTime; // ���� ���������� �߻��� ����(���� ������ ���)


    public AudioSource attackClip;
    AudioSource attackAudio;


    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // nvAgent.destination = playerTr.position;

        StartCoroutine(this.CheckMonsterState());
        

        attackAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //hpSlider.value = hp / maxhp;// �����̴� 
        //nvAgent.destination = playerTr.position;
        //animator.SetBool("IsTrace", true);

        hpSlider.value = hp / maxhp;
    }

    public void Fire()
    {
        if (monsterState == MonsterState.attack && Time.time >= lastFireTime + timeBetFire) // ������°� �߻� ������ ���� && ������ �� �߻� �������� �߻簣�� �̻��� �ð��� ����
        {
            lastFireTime = Time.time; // ������ �� �߻� ���� ����
            StartCoroutine(this.MonsterAction());
        }
    }

    public void GetDamage(float amount)
    {
        hp -= (int) (amount);
        hpSlider.value = hp;

        if (hp <= 0)
        {
            MonsterDie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BossMonster")
        {
            MonsterCtrl_G boss = other.GetComponent<MonsterCtrl_G>();

            if(boss != null)
            {
                boss.GetDamage(attackAmount);
            }
        }
    }

    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTr.position, monsterTr.position);

            if(dist <= attackDist)
            {
                monsterState = MonsterState.attack;
            }
            else if(dist <= traceDist)
            {
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }

    IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.isStopped = true;
                    animator.SetBool("IsTrace", false);
                    break;

                case MonsterState.trace:
                    nvAgent.destination = playerTr.position;
                    nvAgent.isStopped = false;
                    animator.SetBool("IsAttack", false);
                    animator.SetBool("IsTrace", true);
                    break;

                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    StartCoroutine(AttackEffect());
                    break;
            }
            yield return null;
        }
    }

    IEnumerator AttackEffect()
    {
        animator.SetBool("IsAttack", true);
        bossAttackEffect.Play();

        yield return new WaitForSeconds(3.0f);
    }

    void MonsterDie()
    {
        if (isDie == true)
            return;

        StopAllCoroutines();
        isDie = true;
        monsterState = MonsterState.die;
        nvAgent.isStopped = true;
        animator.SetBool("IsDie", true);

        // FindObjectOfType<MenuUI_G>().BossDie();
        gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
        foreach (Collider coll in gameObject.GetComponentsInChildren<SphereCollider>())
        {
            coll.enabled = false;
        }
        Destroy(this.gameObject, 3f); ;
    }


    
   

}
