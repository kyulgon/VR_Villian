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


    public float timeBetFire = 3f; // 몬스터 공각 대기 시간
    private float lastFireTime; // 보스 공격을 마지막으로 발사한 시점


    public AudioSource attackClip;
    AudioSource attackAudio;


    void Start()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        nvAgent.destination = playerTr.position;

        //StartCoroutine(this.CheckMonsterState());
        

        //attackAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //hpSlider.value = hp / maxhp;// 슬라이더 
        nvAgent.destination = playerTr.position;
        animator.SetBool("IsTrace", true);

        hpSlider.value = hp / maxhp;
    }

    public void Fire()
    {
        
        //if (monsterState == MonsterState.attack && Time.time >= lastFireTime + timeBetFire) // 현재상태가 발사 가능한 상태 && 마지막 총 발사 시점에서 발사간격 이상의 시간이 지남
        //{
        //    Debug.Log("fire");
        //    lastFireTime = Time.time; // 마지막 총 발사 시점 갱신
        //    StartCoroutine(this.MonsterAction());
        //}
    }

    //public void GetDamage(float amount) // 데미지 받기
    //{
    //    hp -= (int) (amount);
    //    hpSlider.value = hp;

    //    if (hp <= 0)
    //    {
    //        MonsterDie();
    //    }
    //}

    //private void OnTriggerEnter(Collider other) // bossMonster 충돌
    //{
    //    if(other.tag == "BossMonster")
    //    {
    //        Debug.Log("트리거");
    //        MonsterCtrl_G boss = other.GetComponent<MonsterCtrl_G>();

    //        if(boss != null)
    //        {
    //            boss.GetDamage(attackAmount);
    //        }
    //    }
    //}

    //IEnumerator CheckMonsterState() // 몬스터 상태 바꾸기
    //{
    //    while(!isDie)
    //    {
    //        yield return new WaitForSeconds(0.2f);

    //        float dist = Vector3.Distance(playerTr.position, monsterTr.position);

    //        if(dist <= attackDist)
    //        {
    //            Debug.Log("어택상태");
    //            monsterState = MonsterState.attack;
    //        }
    //        else if(dist <= traceDist)
    //        {
    //            Debug.Log("추적상태");
    //            monsterState = MonsterState.trace;
    //        }
    //        else
    //        {
    //            Debug.Log("멈춤상태");
    //            monsterState = MonsterState.idle;
    //        }
    //    }
    //}

    //IEnumerator MonsterAction() // 상태에 따른 몬스터 액션
    //{
    //    while(!isDie)
    //    {
    //        switch (monsterState)
    //        {
    //            case MonsterState.idle:
    //                nvAgent.isStopped = true;
    //                animator.SetBool("IsTrace", false);
    //                break;

    //            case MonsterState.trace:
    //                nvAgent.destination = playerTr.position;
    //                nvAgent.isStopped = false;
    //                Debug.Log("Trace");
    //                animator.SetBool("IsAttack", false);
    //                animator.SetBool("IsTrace", true);
    //                break;

    //            case MonsterState.attack:
    //                nvAgent.isStopped = true;
    //                StartCoroutine(AttackEffect());
    //                break;
    //        }
    //        yield return null;
    //    }
    //}

    //IEnumerator AttackEffect() // 공격 이펙트
    //{
    //    animator.SetBool("IsAttack", true);
    //    bossAttackEffect.Play();

    //    yield return new WaitForSeconds(3.0f);
    //}

    //void MonsterDie() // 몬스터 다이
    //{
    //    if (isDie == true)
    //        return;

    //    StopAllCoroutines();
    //    isDie = true;
    //    monsterState = MonsterState.die;
    //    nvAgent.isStopped = true;
    //    animator.SetBool("IsDie", true);

    //    // FindObjectOfType<MenuUI_G>().BossDie();
    //    gameObject.GetComponentInChildren<CapsuleCollider>().enabled = false;
    //    foreach (Collider coll in gameObject.GetComponentsInChildren<SphereCollider>())
    //    {
    //        coll.enabled = false;
    //    }
    //    Destroy(this.gameObject, 3f); ;
    //}


    
   

}
