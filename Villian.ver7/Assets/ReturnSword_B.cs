using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnSword_B : MonoBehaviour
{
    [SerializeField]
    GameObject cab;
    private Transform tr;
    public float attackAmount = 25f;
    public AudioClip swordHit;
    AudioSource hitSource;
    // Start is called before the first frame update
    void Start()
    {
        hitSource = GetComponent<AudioSource>();
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
            //Debug.Log("Sword has fallen!");
            tr = cab.GetComponent<Transform>();
            this.gameObject.transform.position = tr.transform.position;
        }
        if (other.GetComponent<IDamage>() != null)
        {
            print(other.GetComponent<IDamage>());
            other.GetComponent<IDamage>().GetDamage(attackAmount);
            hitSource.PlayOneShot(swordHit);
        }
    }
}
