using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class grenedeEffect : MonoBehaviour
{
    public float speed = 6f;

    private int index = 0;
    private Rigidbody bulletRigidbody;

    public float attackAmount = 100f;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
        

        Destroy(gameObject, 2f);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Dragon1_C")
        {
            MonsterCtrl_C mst = other.GetComponent<MonsterCtrl_C>();
            if (mst != null)
            {
                mst.GetDamage(attackAmount);
            }
            //swordAudio.PlayOneShot(swordHit);
        }
        if (other.name == "Dragon2_C")
        {
            MonsterCtrl2_C mst2 = other.GetComponent<MonsterCtrl2_C>();
            if (mst2 != null)
            {
                mst2.GetDamage(attackAmount);
            }
            //swordAudio.PlayOneShot(swordHit);
        }
        if (other.name == "Dragon3_C")
        {
            MonsterCtrl3_C mst3 = other.GetComponent<MonsterCtrl3_C>();
            if (mst3 != null)
            {
                mst3.GetDamage(attackAmount);
            }
            //swordAudio.PlayOneShot(swordHit);
        }
        if (other.name == "Dragon4_C")
        {
            MonsterCtrl4_C mst4 = other.GetComponent<MonsterCtrl4_C>();
            if (mst4 != null)
            {
                mst4.GetDamage(attackAmount);
            }
            //swordAudio.PlayOneShot(swordHit);
        }
        if (other.name == "Dragon5_C")
        {
            MonsterCtrl5_C mst5 = other.GetComponent<MonsterCtrl5_C>();
            if (mst5 != null)
            {
                mst5.GetDamage(attackAmount);
            }
            //swordAudio.PlayOneShot(swordHit);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
