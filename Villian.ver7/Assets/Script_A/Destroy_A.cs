using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy_A : MonoBehaviour
{
    public List<GameObject> Weapons = new List<GameObject>();

    [SerializeField]


    GameObject getObject;
    // public bool getWeapon = false;

    //public AudioSource GetWeapon;
    //public TimeAttack timeAttack;


    //public AudioSource SwordGetWeapon;
    //public AudioClip SwordGetItem;

    private AudioSource sound;
    public AudioClip soundClip;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        Debug.Log(sound);
    }

    public void GrabSound()
    {
        sound.PlayOneShot(soundClip);
        Debug.Log("사운드 함수 들어옴");
    }

    public void DestroyFunc()
    {
        if (sound != null)
        {
            GrabSound();
        }
        if (gameObject.name == "Gun")
        {
            Weapons.RemoveAt(0);

            //SwordGetWeapon.PlayOneShot(SwordGetItem);
            //SwordGetWeapon.Play();

            Destroy(gameObject);


            //timeAttack.Weapons.RemoveAt(0);

            //Debug.Log(timeAttack.Weapons.Count);
            Debug.Log(gameObject.name);



        }
        if (gameObject.name == "Sword")
        {
            Weapons.RemoveAt(1);

            //SwordGetWeapon.PlayOneShot(SwordGetItem);
            //SwordGetWeapon.Play();

            Destroy(gameObject);
            //timeAttack.Weapons.RemoveAt(0);

            //Debug.Log(timeAttack.Weapons.Count);
            Debug.Log(gameObject.name);

        }
        if (gameObject.name == "Grenade")
        {
            Weapons.RemoveAt(2);

            //SwordGetWeapon.PlayOneShot(SwordGetItem);
            //SwordGetWeapon.Play();

            Destroy(gameObject);
            //timeAttack.Weapons.RemoveAt(0);

            //Debug.Log(timeAttack.Weapons.Count);
            Debug.Log(gameObject.name);

        }


        //GameObject obj = new GameObject();
        //Weapons.Add(obj);
        //Debug.Log(Weapons.Count);

        //Destroy(gameObject);
        //Debug.Log("destroy");

    }




}
