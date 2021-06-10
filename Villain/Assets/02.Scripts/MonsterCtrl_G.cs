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


    public float traceDist = 10.0f; // 추적 사정거리
    public float attackDist = 15f; // 공격 사정거리
    public ParticleSystem bossAttackEffect; // 보스공격 이펙트

    private bool isDie = false; // 몬스터 사망 여부
    private float attackAmount = 15.0f;

    public float hp = 100.0f;
    private float maxhp = 100f;
    public Slider hpSlider;

    public AudioSource attackClip;
    AudioSource attackAudio;

    public GameObject monsterbullet;
    private float rate;
    private float timeAfterSpawn;
    void Start()
    {
        
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // nvAgent.destination = playerTr.position;

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());

        attackAudio = GetComponent<AudioSource>();
        rate = Random.Range(1f, 4f);
        timeAfterSpawn = 0;
    }

    void Update()
    {
        //hpSlider.value = hp / maxhp;// 슬라이더 
        //nvAgent.destination = playerTr.position;
        //animator.SetBool("IsTrace", true);

        hpSlider.value = hp / maxhp;
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= rate)
        {
            timeAfterSpawn = 0f;
            if(Vector3.Distance(playerTr.position, this.gameObject.transform.position) <= 50.0f)
            {
                GameObject bullet = Instantiate(monsterbullet, this.transform.position, this.transform.rotation);
                bullet.transform.LookAt(playerTr);
            }
            rate = Random.Range(1f, 4f);
        }
    }

    public void GetDamage(float amount)
    {
        hp -= (int)(amount);
        hpSlider.value = hp;

        if (hp < 0)
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

        Destroy(gameObject, 3f);
    }
}
