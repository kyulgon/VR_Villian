using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController_G : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    public float hp = 100.0f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(float amount)
    {
        hp -= amount;

        if(hp < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        FindObjectOfType<GameManager_G>().EndGame();
    }

}
