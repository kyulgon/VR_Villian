using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBullet_G : MonoBehaviour
{
    public float attackAmount = 35.0f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "BossMonster")
    //    {
    //        MonsterCtrl_G monster = other.GetComponent<MonsterCtrl_G>();

    //        if(monster != null)
    //        {
    //            monster.GetDamage(attackAmount);
    //        }
    //    }

    //    Destroy(gameObject);
    //}
}
