using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_B : MonoBehaviour
{
    public float attackAmount = 25f;
    //public AudioClip swordHit;
    public AudioClip swordSwing;
    public GameObject trail;
    //AudioSource swordAudio;

    // Start is called before the first frame update
    void Start()
    {
        //swordAudio = GetComponent<AudioSource>();
        //swordAudio.volume = 3.0f;
        //TrailRenderer trailrenderer = trail.GetComponent<TrailRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        //if (other.name == "Dragon1_C")
        //{
        //    MonsterCtrl_C mst = other.GetComponent<MonsterCtrl_C>();
        //    if (mst != null)
        //    {
        //        mst.GetDamage(attackAmount);
        //    }
        //    swordAudio.PlayOneShot(swordHit);
        //}
        //if (other.name == "Dragon2_C")
        //{
        //    MonsterCtrl2_C mst2 = other.GetComponent<MonsterCtrl2_C>();
        //    if (mst2 != null)
        //    {
        //        mst2.GetDamage(attackAmount);
        //    }
        //    swordAudio.PlayOneShot(swordHit);
        //}
        //if (other.name == "Dragon3_C")
        //{
        //    MonsterCtrl3_C mst3 = other.GetComponent<MonsterCtrl3_C>();
        //    if (mst3 != null)
        //    {
        //        mst3.GetDamage(attackAmount);
        //    }
        //    swordAudio.PlayOneShot(swordHit);
        //}
        //if (other.name == "Dragon4_C")
        //{
        //    MonsterCtrl4_C mst4 = other.GetComponent<MonsterCtrl4_C>();
        //    if (mst4 != null)
        //    {
        //        mst4.GetDamage(attackAmount);
        //    }
        //    swordAudio.PlayOneShot(swordHit);
        //}
        //if (other.name == "Dragon5_C")
        //{
        //    MonsterCtrl5_C mst5 = other.GetComponent<MonsterCtrl5_C>();
        //    if (mst5 != null)
        //    {
        //        mst5.GetDamage(attackAmount);
        //    }
        //    swordAudio.PlayOneShot(swordHit);
        //}
        

        if (other.GetComponent<IDamage>() != null)
        {
            print(other.GetComponent<IDamage>());
            other.GetComponent<IDamage>().GetDamage(attackAmount);
        }
    }
    public void swordgrabbed()
    {
        if (trail.GetComponent<TrailRenderer>() != null && trail.GetComponent<TrailRenderer>().enabled == false)
        {
            trail.GetComponent<TrailRenderer>().enabled = true;
        }
    }
    public void sworddropped()
    {
        if(trail.GetComponent<TrailRenderer>() != null && trail.GetComponent<TrailRenderer>().enabled==true)
        {
            trail.GetComponent<TrailRenderer>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //float x = GetComponent<Rigidbody>().velocity.x;
        //float y = GetComponent<Rigidbody>().velocity.y;
        //float z = GetComponent<Rigidbody>().velocity.z;
        //if (Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) > 0.3f)
        //{
        //    swordAudio.PlayOneShot(swordSwing);
        //    Debug.Log("swing!");
        //}
        
    }
}
