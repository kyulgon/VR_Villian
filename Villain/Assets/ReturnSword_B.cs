using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSword_B : MonoBehaviour
{
    [SerializeField]
    GameObject cab;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tr = cab.GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Under"))
        {
            Debug.Log("Sword has fallen!");
            tr = cab.GetComponent<Transform>();
            this.gameObject.transform.position = tr.transform.position;
        }
    }
}
