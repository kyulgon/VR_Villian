using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl2_C : MonoBehaviour, IDamage
{
    public enum MonsterState { idle, trace, attack, die };
    public MonsterState monsterState = MonsterState.idle;
    private Transform monsterTr;
    private Transform playerTr;
    private Transform towerTr;
    private Transform fireTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    private Animator animator;

    public float playerTraceDist = 15.0f;
    public float attackDist = 7.0f;
    public float towerAttackDist = 10.0f;
    private bool isDie = false;

    private int hp = 100;
    public int MaxHp = 100;
    public Slider hpSlider;

    public GameObject bulletPrefab;

    public AudioClip[] clips;
    public AudioSource audioSource;

    [SerializeField]
    GameObject hitEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet_B")
        {
            Instantiate(hitEffect, other.transform.position, this.gameObject.transform.rotation);
        }
        else if(other.tag == "Sword")
        {
            Instantiate(hitEffect, this.transform.position, this.gameObject.transform.rotation);
        }
    }
    void Start()
    {
        hpSlider.value = 100;

        monsterTr = this.gameObject.GetComponent<Transform>();
        playerTr = GameObject.Find("Player_B").GetComponent<Transform>();
        towerTr = GameObject.Find("Tower Mage").GetComponent<Transform>();
        fireTr = GameObject.Find("FirePosition2_C").GetComponent<Transform>();

        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());

    }

    void Update()
    {
        float monsterTowerDist = Vector3.Distance(monsterTr.position, towerTr.position);
        float playerMonsterDist = Vector3.Distance(playerTr.position, monsterTr.position);

        //if (playerMonsterDist <= towerTraceDist && playerMonsterDist <= monsterTowerDist)
        //{
        //    nvAgent.destination = playerTr.position;
        //    transform.LookAt(playerTr);
        //}

        //else
        //{
        //    nvAgent.destination = towerTr.position;
        //    transform.LookAt(towerTr);
        //}

        if (playerMonsterDist <= playerTraceDist)// && playerMonsterDist <= monsterTowerDist
        {
            nvAgent.destination = playerTr.position;
            transform.LookAt(playerTr);
        }

        else
        {
            nvAgent.destination = towerTr.position;
            transform.LookAt(towerTr);
        }
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);//슬립사용.yield return null.
            float monsterTowerDist = Vector3.Distance(monsterTr.position, towerTr.position);
            float playerMonsterDist = Vector3.Distance(playerTr.position, monsterTr.position);


            if (playerMonsterDist <= attackDist || monsterTowerDist <= towerAttackDist)///playerMonsterDist <= towerTraceDist && playerMonsterDist <= monsterTowerDist
            {
                monsterState = MonsterState.attack;
                Debug.Log("attack");
            }
            else
            {
                monsterState = MonsterState.trace;

            }
        }
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.isStopped = true;
                    animator.SetBool("Walk", false);
                    break;
                case MonsterState.trace:
                    nvAgent.isStopped = false;
                    animator.SetBool("Walk", true);
                    animator.SetBool("Shoot", false);

                    break;
                case MonsterState.attack:
                    nvAgent.isStopped = true;
                    //animator.SetBool("Walk", false);
                    animator.SetBool("Shoot", true);

                    break;
            }
            yield return null;
        }
    }

    public void GetDamage(float amount)
    {
        //audioSource.PlayOneShot(clips[1]);
        hp -= (int)(amount);
        //animator.SetBool("Get Hit", true);
        hpSlider.value = hp;

        if (hp <= 0)
        {
            GameManager gm = new GameManager();
            if (isDie == true) return;//return

            StopAllCoroutines();
            isDie = true;
            monsterState = MonsterState.die;
            nvAgent.isStopped = true;
            animator.SetBool("Die", true);
            GameManager.Instance.Count--;
            Debug.Log(GameManager.Instance.Count);
            Destroy(this.gameObject, 3f);

            //Instantiate(hitEffect, this.transform.position, this.transform.rotation);
        }
        else
        {
            animator.SetTrigger("Get Hit");
        }
    }

    void CreateBullet()//attack일때.
    {
        GameObject bullet = Instantiate(bulletPrefab, fireTr.position, transform.rotation);
        if (nvAgent.destination == playerTr.position)//playerAttack일때.
        {
            bullet.transform.LookAt(playerTr);
        }
        else if (nvAgent.destination == towerTr.position)//playerAttack일때.
        {
            bullet.transform.LookAt(playerTr);
        }
        else
        {

        }
        //fireAudio.PlayOneShot(fireClip);
    }

    void WalkAudio()//animationEvent
    {
        audioSource.PlayOneShot(clips[0]);

    }
}
