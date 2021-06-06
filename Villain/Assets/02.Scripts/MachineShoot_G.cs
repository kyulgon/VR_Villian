using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineShoot_G : MonoBehaviour
{
    public GameObject bullerPrefab; // 총알 프리팹
    // public GameObject muzzleFlashPrefab; // 총소리
    public Transform barrelLocation; // 총알 나오는 위치

    public float shotPower = 100f;

    public AudioClip fireClip; // 총 발사 사운드 클립
    AudioSource fireAudio; // 건에 추가한 오디오소스컴포넌트를 담을 변수


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        fireAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    
        //}
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        // GameObject tempFlash;
        GetComponent<Animator>().SetBool("Fire", true);
        StartCoroutine(StopShoot());
        Instantiate(bullerPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower * 100);

        fireAudio.PlayOneShot(fireClip);
        // tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
    }

    IEnumerator StopShoot()
    {
        GetComponent<Animator>().SetBool("Fire", false);
        yield return new WaitForSeconds(1.0f);
    }
}
