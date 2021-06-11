using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_C : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dragon1_C")
        {
            MonsterCtrl_C MC = other.GetComponent<MonsterCtrl_C>();
            MC.GetDamage(20);///인수로변경.
        }
        else if (other.gameObject.name == "Dragon2_C")
        {
            MonsterCtrl2_C MC2 = other.GetComponent<MonsterCtrl2_C>();
            MC2.GetDamage(20);///인수로변경.
        }
        else if (other.gameObject.name == "Dragon3_C")
        {
            MonsterCtrl3_C MC3 = other.GetComponent<MonsterCtrl3_C>();
            MC3.GetDamage(20);///인수로변경.
        }
        else if (other.gameObject.name == "Dragon4_C")
        {
            MonsterCtrl4_C MC4 = other.GetComponent<MonsterCtrl4_C>();
            MC4.GetDamage(20);///인수로변경.
        }
        else if (other.gameObject.name == "Dragon5_C")
        {
            MonsterCtrl5_C MC5 = other.GetComponent<MonsterCtrl5_C>();
            MC5.GetDamage(20);///인수로변경.
        }
        else
        {

        }

        
        
    }
}
