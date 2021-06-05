using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineShoot_G : MonoBehaviour
{
    public GameObject bullerPrefab; // ÃÑ¾Ë ÇÁ¸®ÆÕ
    // public GameObject muzzleFlashPrefab; // ÃÑ¼Ò¸®
    public Transform barrelLocation; // ÃÑ¾Ë ³ª¿À´Â À§Ä¡

    public float shotPower = 100f;

    public bool isGrab = true;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        //if(Input.GetButtonDown("Fire1"))
        //{
        //    GetComponent<Animator>().SetTrigger("Fire");
        //}
    }

    public void Shoot()
    {
        if(isGrab == true)
        {
            // GameObject tempFlash;
            Instantiate(bullerPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            // tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        }
    }
}
