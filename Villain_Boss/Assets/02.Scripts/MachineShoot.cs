using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineShoot : MonoBehaviour
{
    public GameObject bullerPrefab; // �Ѿ� ������
    // public GameObject muzzleFlashPrefab; // �ѼҸ�
    public Transform barrelLocation; // �Ѿ� ������ ��ġ

    public float shotPower = 100f;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }
    }

    public void Shoot()
    {
        // GameObject tempFlash;
        Instantiate(bullerPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        // tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
    }
}
