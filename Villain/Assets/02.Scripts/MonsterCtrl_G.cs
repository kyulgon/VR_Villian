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


    public float traceDist = 100.0f; // ���� �����Ÿ�
    public float attackDist = 10f; // ���� �����Ÿ�

    public float hp = 100.0f;
    private bool isDie = false; // ���� ��� ����
    private float attackAmount = 15.0f;
    private float maxhp = 100f;

    public Slider hpSlider;

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
        StartCoroutine(this.MonsterAction());

        attackAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //hpSlider.value = hp / maxhp;// �����̴� 
        //nvAgent.destination = playerTr.position;
        //animator.SetBool("IsTrace", true);
    }

    public void GetDamage(float amount)
    {
        hp -= (int) (amount);
        animator.SetTrigger("IsHit");
        hpSlider.value = hp;//
        if (hp < 0)
        {
            gameObject.SetActive(false);
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
                    animator.SetBool("IsAttack", true);
                    break;
            }
            yield return null;
        }
    }

    void MonsterDie()
    {
        if (isDie = true)
            return;

        StopAllCoroutines();
        isDie = true;
        monsterState = MonsterState.die;
        nvAgent.isStopped = true;
        animator.SetTrigger("IsDie");

        FindObjectOfType<MenuUI_G>().BossDie();
    }
}
