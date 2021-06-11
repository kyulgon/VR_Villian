////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;

////public class Grenade_B : MonoBehaviour
////{
////    public LayerMask whatIsMonster;
////    public GameObject explosionParticle;//ParticleSystem
////    public AudioSource explosionAudio;//AudioSource
////    public float maxDamage = 100f;
////    public float explosionForce = 1000f;//자기 반경으로 1000force힘으로 튕겨나가게
////    public float lifeTime = 3f;
////    public float explosionRadius = 20f;
////    void Start()
////    {
////        Destroy(gameObject, lifeTime);
////    }

////    private void OnTriggerEnter(Collider other)
////    {
////        //가상의 구를 그려서 그 안에 있는 collider를 가져오려고 함
////        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);//그 위치에 radius반경으로 whatismonster할당된 애들만 가져옴
////        //Collier[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);
////        if (colliders.Length <= 0)
////        {
////            explosionParticle.SetActive(true);
////            //explosionAudio.SetActive(true);
////            //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
////            //explosionParticle.Play();
////            //explosionAudio.Play();
////            //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
////            Destroy(gameObject,2f);
////        }
////        else if(colliders.Length >0)
////        {
////            for (int i = 0; i < colliders.Length; i++)
////            {
////                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
////                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//폭발의 위치와 폭발력, 폭발 반경
////                MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
////                float damage = CalculateDamage(colliders[i].transform.position);
////                targetMonster.GetDamage(damage);

////            }
////            explosionParticle.SetActive(true);
////            //explosionAudio.SetActive(true);
////            //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
////            //explosionParticle.Play();
////            //explosionAudio.Play();
////            //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
////            Destroy(gameObject,2f);
////        }
////        //for (int i = 0; i < colliders.Length; i++)
////        //{
////        //    Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
////        //    targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//폭발의 위치와 폭발력, 폭발 반경
////        //    MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
////        //    float damage = CalculateDamage(colliders[i].transform.position);
////        //    targetMonster.GetDamage(damage);

////        //}
////        //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
////        //explosionParticle.Play();
////        //explosionAudio.Play();
////        //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
////        //Destroy(gameObject);
////    }
////    private float CalculateDamage(Vector3 targetPosition) // 어떤 위치를 주면 내 위치에서 그 위치까지의 거리르 재서 데미지 얼마 받을지 계산, 데미지를 차등으로 주려고
////    {
////        Vector3 explosionToTarget = targetPosition - transform.position;
////        float distance = explosionToTarget.magnitude;
////        float edgeToCenterDistance = explosionRadius - distance; //가쪽에서 안쪽으로 얼마나 들어갔냐
////        float percentage = edgeToCenterDistance / explosionRadius;
////        float damage = maxDamage * percentage;
////        damage = Mathf.Max(0, damage);
////        return damage;

////    }
////    void Update()
////    {

////    }
////}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR;
//using UnityEngine.XR.Interaction.Toolkit;

//public class Grenade_B : MonoBehaviour
//{
//    public float delay = 2f;
//    public GameObject explosionEffect;
//    public AudioClip Swing;
//    [SerializeField]
//    AudioSource explosionSound;
//    AudioSource swingAudio;
//    public float radius = 30f;
//    public float force = 10000f;
//    public float maxDamage = 200f;
//    public bool isGrab = false;
//    float countdown;
//    //bool hasExploded = false;
//    Rigidbody rg;
//    Vector3 initpos;
//    public HandState currentGrab;

//    public bool hasThrown;

//    public float x, y, z;
//    //public GameObject movementProvider;
//    void Start()
//    {
//        hasThrown = false;
//        swingAudio = GetComponent<AudioSource>();
//        rg = GetComponent<Rigidbody>();
//        countdown = delay;
//        //  rg.velocity = Vector3.up * 10f;
//        //currentGrab = HandState.NONE;
//    }
//    void Update()
//    {
//        countdown -= Time.deltaTime;
//        //if(countdown<=0 && !hasExploded)
//        //{
//        //    Explode();
//        //    hasExploded = true;
//        //}
//        x = GetComponent<Rigidbody>().velocity.x;
//        y = GetComponent<Rigidbody>().velocity.y;
//        z = GetComponent<Rigidbody>().velocity.z;
//        //Debug.Log($"x: {x}, y:{y}, z:{z}");
//        //if (Mathf.Abs(x)+ Mathf.Abs(z) > 50f )
//        //{
//        //    Invoke("Explode",1.5f);
//        //    //hasExploded = true;
//        //}
//        //if (Mathf.Abs(y) > 1f)
//        //{
//        //    Invoke("Explode", 1.5f);
//        //    //hasExploded = true;
//        //}

//    }
//    public void CatchObject()
//    {
//        Debug.Log("grabbed!");
//        if (this.gameObject.GetComponent<TrailRenderer>().enabled == true)
//        {
//            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
//        }
//    }


//    public void throwObject()
//    {
//        //Vector3 dir = this.transform.position - initpos;
//        //Rigidbody rg = this.GetComponent<Rigidbody>();
//        //rg.velocity=dir* 30000f;
//        //Debug.Log("bomb");
//        //var mp = movementProvider.GetComponent<MovementProvider_B>();
//        //Swing = mp.swing;
//        var cb = GameObject.Find("PlayerRightControllerHand_B (1)").GetComponent<AudioSource>();
//        //cb.Play();
//        cb.volume = 2f;
//        var gn = GameObject.FindWithTag("Grenade_B");
//        if (cb != null)
//        {
//            //this.gameObject.GetComponent<TrailRenderer>().enabled = true;
//            cb.Play();
//        }

//        //cb.GetComponent<AudioSource>().Play();

//    }
//    public void Explode()
//    {
//        //show effect
//        GameObject temp = Instantiate(explosionEffect, transform.position, transform.rotation);
//        //explosionSound.Play();
//        //Get nearby objects
//        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

//        foreach (Collider nearbyObject in collidersToDestroy)
//        {

//            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
//            if (rb != null)
//            {
//                //Add force
//                rb.AddExplosionForce(force, transform.position, radius);
//                if (nearbyObject.tag == "Monster")
//                {
//                    MonsterCtrl_C targetMonster = nearbyObject.GetComponent<MonsterCtrl_C>();
//                    float damage = CalculateDamage(nearbyObject.transform.position);
//                    targetMonster.GetDamage(damage);
//                }
//            }
//            //damage
//            Destructible_B dest = nearbyObject.GetComponent<Destructible_B>();
//            if (dest != null)
//            {
//                dest.Destroyy();
//            }
//        }
//        //Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
//        //foreach (Collider nearbyObject in collidersToMove)
//        //{
//        //    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
//        //    if (rb != null)
//        //    {
//        //        //Add force
//        //        rb.AddExplosionForce(force, transform.position, radius);
//        //    }
//        //}

//        //remove grenade
//        Destroy(this.gameObject);
//        Destroy(temp, 1.9f);
//    }

//    private float CalculateDamage(Vector3 targetPosition)
//    {
//        Vector3 explosionTarget = targetPosition - transform.position;
//        float distance = explosionTarget.magnitude;
//        float edgeToCenterDistance = radius - distance;
//        float percentage = edgeToCenterDistance / radius;
//        float damage = maxDamage * percentage;
//        maxDamage = Mathf.Max(0, damage);
//        return damage;
//    }

//    //private void OnTriggerStay(Collider other)
//    //{
//    //    if (!other.gameObject.name.Contains("Controller") && !other.gameObject.name.Contains("Cabinet"))
//    //    {
//    //        Invoke("Explode", 1.5f);
//    //    }
//    //}
//    //private void OnTriggerExit(Collider other)
//    //{
//    //    Debug.Log("123");
//    //    //손에서 빠져나가면 2초 뒤에 폭발
//    //    if (other.gameObject.name.Contains("Hand"))
//    //    {
//    //        Debug.Log("hand123");
//    //        Invoke("Explode", delay);
//    //    }
//    //}
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.name.Contains("Under"))
//        {
//            Invoke("Explode", 2f);
//        }
//        //Debug.Log(collision.collider.name);
//    }

//    //private void OnTriggerEnter(Collider other)
//    //{
//    //Debug.Log(other.name);
//    //}
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Grenade_B : MonoBehaviour
//{
//    public LayerMask whatIsMonster;
//    public GameObject explosionParticle;//ParticleSystem
//    public AudioSource explosionAudio;//AudioSource
//    public float maxDamage = 100f;
//    public float explosionForce = 1000f;//자기 반경으로 1000force힘으로 튕겨나가게
//    public float lifeTime = 3f;
//    public float explosionRadius = 20f;
//    void Start()
//    {
//        Destroy(gameObject, lifeTime);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        //가상의 구를 그려서 그 안에 있는 collider를 가져오려고 함
//        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);//그 위치에 radius반경으로 whatismonster할당된 애들만 가져옴
//        //Collier[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsMonster);
//        if (colliders.Length <= 0)
//        {
//            explosionParticle.SetActive(true);
//            //explosionAudio.SetActive(true);
//            //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
//            //explosionParticle.Play();
//            //explosionAudio.Play();
//            //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
//            Destroy(gameObject,2f);
//        }
//        else if(colliders.Length >0)
//        {
//            for (int i = 0; i < colliders.Length; i++)
//            {
//                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
//                targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//폭발의 위치와 폭발력, 폭발 반경
//                MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
//                float damage = CalculateDamage(colliders[i].transform.position);
//                targetMonster.GetDamage(damage);

//            }
//            explosionParticle.SetActive(true);
//            //explosionAudio.SetActive(true);
//            //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
//            //explosionParticle.Play();
//            //explosionAudio.Play();
//            //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
//            Destroy(gameObject,2f);
//        }
//        //for (int i = 0; i < colliders.Length; i++)
//        //{
//        //    Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
//        //    targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);//폭발의 위치와 폭발력, 폭발 반경
//        //    MonsterCtrl_C targetMonster = colliders[i].GetComponent<MonsterCtrl_C>();
//        //    float damage = CalculateDamage(colliders[i].transform.position);
//        //    targetMonster.GetDamage(damage);

//        //}
//        //explosionParticle.transform.parent = null;//파티클이 수류탄에서 빠져나옴
//        //explosionParticle.Play();
//        //explosionAudio.Play();
//        //Destroy(explosionParticle.gameObject, explosionParticle.main.duration);//explosionParticle.duration
//        //Destroy(gameObject);
//    }
//    private float CalculateDamage(Vector3 targetPosition) // 어떤 위치를 주면 내 위치에서 그 위치까지의 거리르 재서 데미지 얼마 받을지 계산, 데미지를 차등으로 주려고
//    {
//        Vector3 explosionToTarget = targetPosition - transform.position;
//        float distance = explosionToTarget.magnitude;
//        float edgeToCenterDistance = explosionRadius - distance; //가쪽에서 안쪽으로 얼마나 들어갔냐
//        float percentage = edgeToCenterDistance / explosionRadius;
//        float damage = maxDamage * percentage;
//        damage = Mathf.Max(0, damage);
//        return damage;

//    }
//    void Update()
//    {

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Grenade_B : MonoBehaviour
{
    public float delay = 2f;
    public GameObject explosionEffect;
    public AudioClip Swing;
    [SerializeField]
    AudioSource explosionSound;
    AudioSource swingAudio;
    public float radius = 20f;
    public float force = 700f;
    public float maxDamage = 200f;
    public bool isGrab = false;
    float countdown;
    //bool hasExploded = false;
    Rigidbody rg;
    Vector3 initpos;
    public HandState currentGrab;

    public bool hasThrown;

    public float x, y, z;
    //public GameObject movementProvider;
    void Start()
    {
        hasThrown = false;
        swingAudio = GetComponent<AudioSource>();
        rg = GetComponent<Rigidbody>();
        countdown = delay;
        //MonsterCtrl_C targetMonster = GetComponent<MonsterCtrl_C>();
        //MonsterCtrl2_C targetMonster1 = GetComponent<MonsterCtrl2_C>();
        //MonsterCtrl3_C targetMonster2 = GetComponent<MonsterCtrl3_C>();
        //MonsterCtrl4_C targetMonster3 = GetComponent<MonsterCtrl4_C>();
        //MonsterCtrl5_C targetMonster4 = GetComponent<MonsterCtrl5_C>();
        //  rg.velocity = Vector3.up * 10f;
        //currentGrab = HandState.NONE;
    }
    void Update()
    {
        

    }
    public void CatchObject()
    {
        Debug.Log("grabbed!");
        if (this.gameObject.GetComponent<TrailRenderer>().enabled == true)
        {
            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        }
    }


    public void throwObject()
    {
        //Vector3 dir = this.transform.position - initpos;
        //Rigidbody rg = this.GetComponent<Rigidbody>();
        //rg.velocity=dir* 30000f;
        //Debug.Log("bomb");
        //var mp = movementProvider.GetComponent<MovementProvider_B>();
        //Swing = mp.swing;
        var cb = GameObject.Find("PlayerRightControllerHand_B (1)").GetComponent<AudioSource>();
        //cb.Play();
        cb.volume = 2f;
        var gn = GameObject.FindWithTag("Grenade_B");
        if (cb != null)
        {
            Debug.Log("grenade has been thrown!");
            //this.gameObject.GetComponent<TrailRenderer>().enabled = true;
            cb.Play();
        }

        //cb.GetComponent<AudioSource>().Play();

    }
    public void Explode()
    {
        //show effect
        GameObject temp = Instantiate(explosionEffect, transform.position, transform.rotation);
        //explosionSound.Play();
        //Get nearby objects
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy)
        {

            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Add force
                rb.AddExplosionForce(force, transform.position, radius);
                if (nearbyObject.tag == "Monster")
                {
                    
                    MonsterCtrl_C targetMonster = nearbyObject.GetComponent<MonsterCtrl_C>();
                    if (targetMonster != null)
                    {
                        Debug.Log("monster got hit");
                        float damage = CalculateDamage(nearbyObject.transform.position);
                        targetMonster.GetDamage(damage);
                    }
                    MonsterCtrl2_C targetMonster2 = nearbyObject.GetComponent<MonsterCtrl2_C>();
                    if (targetMonster2 != null)
                    {
                        Debug.Log("monster2 got hit");
                        float damage = CalculateDamage(nearbyObject.transform.position);
                        targetMonster2.GetDamage(damage);
                    }
                    MonsterCtrl3_C targetMonster3 = nearbyObject.GetComponent<MonsterCtrl3_C>();
                    if (targetMonster3 != null)
                    {
                        Debug.Log("monster3 got hit");
                        float damage = CalculateDamage(nearbyObject.transform.position);
                        targetMonster3.GetDamage(damage);
                    }
                    MonsterCtrl4_C targetMonster4 = nearbyObject.GetComponent<MonsterCtrl4_C>();
                    if (targetMonster4 != null)
                    {
                        Debug.Log("monster4 got hit");
                        float damage = CalculateDamage(nearbyObject.transform.position);
                        targetMonster4.GetDamage(damage);
                    }
                    MonsterCtrl5_C targetMonster5 = nearbyObject.GetComponent<MonsterCtrl5_C>();
                    if (targetMonster5 != null)
                    {
                        Debug.Log("monster5 got hit");
                        float damage = CalculateDamage(nearbyObject.transform.position);
                        targetMonster5.GetDamage(damage);
                    }
                }
            }
            //damage
            Destructible_B dest = nearbyObject.GetComponent<Destructible_B>();
            if (dest != null)
            {
                dest.Destroyy();
            }
        }
        //Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
        //foreach (Collider nearbyObject in collidersToMove)
        //{
        //    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
        //    if (rb != null)
        //    {
        //        //Add force
        //        rb.AddExplosionForce(force, transform.position, radius);
        //    }
        //}

        //remove grenade
        Destroy(this.gameObject);
        Destroy(temp, 1.9f);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionTarget = targetPosition - transform.position;
        float distance = explosionTarget.magnitude;
        float edgeToCenterDistance = radius - distance;
        float percentage = edgeToCenterDistance / radius;
        float damage = maxDamage * percentage;
        maxDamage = Mathf.Max(0, damage);
        return damage;
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (!other.gameObject.name.Contains("Controller") && !other.gameObject.name.Contains("Cabinet"))
    //    {
    //        Invoke("Explode", 1.5f);
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("123");
    //    //손에서 빠져나가면 2초 뒤에 폭발
    //    if (other.gameObject.name.Contains("Hand"))
    //    {
    //        Debug.Log("hand123");
    //        Invoke("Explode", delay);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Under"))
        {
            Invoke("Explode", 2f);
        }
        //Debug.Log(collision.collider.name);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //Debug.Log(other.name);
    //}
}