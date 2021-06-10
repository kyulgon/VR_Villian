using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet_G : MonoBehaviour
{
    private float attackAmount = 30f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var pl = other.GetComponent<MachineController_G>();
            pl.GetDamage(attackAmount);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
