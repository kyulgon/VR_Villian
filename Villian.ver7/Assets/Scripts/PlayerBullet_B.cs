using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_B : MonoBehaviour
{
    private float attackAmount = 35.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); //5초후 제거!
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dragon1_C") // BulletSpawner
        {
            MonsterCtrl_C monster1 = other.GetComponent<MonsterCtrl_C>();

            if (monster1 != null)
            {
                monster1.GetDamage(attackAmount);
            }
        }
        if (other.gameObject.name == "Dragon2_C") // BulletSpawner
        {
            MonsterCtrl2_C monster2 = other.GetComponent<MonsterCtrl2_C>();

            if (monster2 != null)
            {
                monster2.GetDamage(attackAmount);
            }
        }
        if (other.gameObject.name == "Dragon3_C") // BulletSpawner
        {
            MonsterCtrl3_C monster3 = other.GetComponent<MonsterCtrl3_C>();

            if (monster3 != null)
            {
                monster3.GetDamage(attackAmount);
            }
        }
        if (other.gameObject.name == "Dragon4_C") // BulletSpawner
        {
            MonsterCtrl4_C monster4 = other.GetComponent<MonsterCtrl4_C>();

            if (monster4 != null)
            {
                monster4.GetDamage(attackAmount);
            }
        }
        if (other.gameObject.name == "Dragon5_C") // BulletSpawner
        {
            MonsterCtrl5_C monster5 = other.GetComponent<MonsterCtrl5_C>();

            if (monster5 != null)
            {
                monster5.GetDamage(attackAmount);
            }
        }
        //if(other.gameObject.tag =="Shootable")
        //{
        //    Destroy(gameObject);
        //}
    }
}
