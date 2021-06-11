using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    public float speed = 6f;

    private int index = 0;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
        

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "Tower Mage")
        {
            towerCtrl tower = other.GetComponent<towerCtrl>();
            tower.GetDamage(1);
        }
        if (other.name == "Player_B")
        {
            PlayerCtrl_C Player = other.GetComponent<PlayerCtrl_C>();
            Player.PlayerHP();
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
