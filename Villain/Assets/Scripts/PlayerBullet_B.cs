using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet_B : MonoBehaviour
{
    public float attackAmount = 35.0f;
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
        if (other.tag == "Monster") // BulletSpawner
        {
            MonsterCtrl_C monster_c = other.GetComponent<MonsterCtrl_C>();

            if (monster_c != null)
            {
                monster_c.GetDamage(attackAmount);
            }
        }
        //else if (other.tag == "Monster2") // Alien Monster
        //{
        //    MonsterCtrl alien = other.GetComponent<MonsterCtrl>();

        //    if (alien != null)
        //    {
        //        alien.GetDamage(attackAmount);
        //    }

        //}
        //else if (other.tag == "START")
        //{
        //    FindObjectOfType<GameManager>().StartGame();
        //}

        //Destroy(gameObject);
    }
}
