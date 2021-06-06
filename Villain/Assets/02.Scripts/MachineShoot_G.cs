using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineShoot_G : MonoBehaviour
{
    public GameObject bullerPrefab; // �Ѿ� ������
    // public GameObject muzzleFlashPrefab; // �ѼҸ�
    public Transform barrelLocation; // �Ѿ� ������ ��ġ

    public float shotPower = 100f;

    public AudioClip fireClip; // �� �߻� ���� Ŭ��
    AudioSource fireAudio; // �ǿ� �߰��� ������ҽ�������Ʈ�� ���� ����


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
