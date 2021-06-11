using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleShoot_B : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;


    public float shotPower = 750f;

    public bool isGrab = false ;

    public AudioClip fireClip; //총 발사 사운드 클립
    AudioSource fireAudio;     //핸드건에 추가한 오디오소스컴포넌트를 담을 변수

    public HandState currentGrab;

    [SerializeField]
    GameObject guncab;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        fireAudio = GetComponent<AudioSource>();
        currentGrab = HandState.NONE;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Under"))
        {
            Debug.Log("Gun has fallen!");
        }
    }
    void Update()
    {
        //여차하면 주석
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    GetComponent<Animator>().SetTrigger("Fire");
        //}
    }

    public void grabGun()
    {
        isGrab = true;
    }

    public void dropGun()
    {
        isGrab = false;
    }

    public void SetGraspState(HandState state)
    {
        currentGrab = state;
    }

    public void SetGraspNONE()
    {
        if(!GetComponent<XRGrabInteractable>().isSelected)
            currentGrab = HandState.NONE;

    }

    public void SetGraspLEFT()
    {
        currentGrab = HandState.LEFT;
    }

    public void SetGraspRIGHT()
    {
        currentGrab = HandState.RIGHT;
    }

    public void Shoot()
    {
        if (isGrab == true)
        {
            GameObject tempFlash;
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
           

            fireAudio.PlayOneShot(fireClip);
        }
    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
