using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_A : MonoBehaviour
{
    public AudioSource GunGetWeapon;
    public AudioClip GunGetItem;

    public GameObject Gun;
    public GameObject Sword;
    public GameObject Grenade;



    // Start is called before the first frame update
    void Start()
    {
        GunGetWeapon = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Gun == null || Sword == null || Grenade == null)
        //{
        //    GetWeapon.PlayOneShot(GetItem);
        //}


        if (Gun == null)
        {
            GunGetWeapon.PlayOneShot(GunGetItem);
            //GetWeapon.Play();
        }

        if (Sword == null)
        {
            GunGetWeapon.PlayOneShot(GunGetItem);
            //GetWeapon.Play();
        }

        if (Grenade == null)
        {
            GunGetWeapon.PlayOneShot(GunGetItem);
            //GetWeapon.Play();
        }


    }

}
