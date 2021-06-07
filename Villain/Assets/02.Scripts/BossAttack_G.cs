using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack_G : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody bossRigidbody;


    void Start()
    {
        bossRigidbody = GetComponent<Rigidbody>();
        bossRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MachineController_G player = other.GetComponent<MachineController_G>();
            player.GetDamage(15.0f);
        }
    }
}
