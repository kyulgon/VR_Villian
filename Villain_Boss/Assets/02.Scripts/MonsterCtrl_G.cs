using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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


    public float traceDist = 100.0f; // 추적 사정거리
    public float attackDist = 10f; // 공격 사정거리
    private bool isDie = false; // 몬스터 사망 여부

    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // nvAgent.destination = playerTr.position;

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());
    }

    void Update()
    {
        nvAgent.destination = playerTr.position;
        animator.SetBool("IsTrace", true);
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
}
