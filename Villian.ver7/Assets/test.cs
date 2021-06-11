using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private int hp = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Sword"))
        {
            //Sword_B sw = other.GetComponent<Sword_B>();
            GetDamage(10f);
        }
    }

    public void GetDamage(float amount)
    {
        hp -= (int)(amount);
        print(hp);

    }
}
