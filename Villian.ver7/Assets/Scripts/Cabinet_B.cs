//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;

//public class Cabinet_B : MonoBehaviour
//{
//    [SerializeField]
//    List<GameObject> objList = new List<GameObject>();
//    [SerializeField]
//    GameObject grenadePrefabs;
//    public XRSocketInteractor sci;

//    private bool getGrenade = false;
//    private int i = 0;
//    private int size = 5;
//    //private int grenadenum=3;
//    //    // Start is called before the first frame update
//    void Start()
//    {
//        //size = 3;
//        //for (int i = 0; i < 3; i++)
//        //{
//        //    objlist.add (instantiate(grenadeprefabs, this.transform.position, this.transform.rotation));

//        //        objlist[i].getcomponent<rigidbody>().iskinematic = true;

//        //}
//        //objlist[0].getcomponent<rigidbody>().iskinematic = false;
//        // objList.Add = GetComponent<GameObject>();
//    }

//    //    // Update is called once per frame
//    void Update()
//    {
//        //Debug.Log("A");

//        //CoroutineSet();



//    }
//    public void createGren()
//    {
//        if (size > 0)
//        {
//            XRGrabInteractable r;
//            r = Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation).GetComponent<XRGrabInteractable>();
//            sci.startingSelectedInteractable = r;
//            size--;
//        }
//        //XRGrabInteractable r;
//        //r = Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation).GetComponent<XRGrabInteractable>();
//        //Debug.Log(r);
//        //sci.startingSelectedInteractable = r;
//    }

//    void CoroutineSet()
//    {
//        getGrenade = false;
//        if (!getGrenade)
//        {
//            StartCoroutine(CreateDelay());
//        }

//    }

//    IEnumerator CreateDelay()
//    {
//        Debug.Log("B");
//        yield return new WaitForSeconds(3.0f);
//        getGrenade = true;

//        if (getGrenade)
//        {
//            Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
//            Debug.Log("c");
//            getGrenade = false;
//        }

//        //if (gameObject.transform.Find("Grenade_B (3) Variant(Clone)") == null)
//        //{
//        //Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
//        //Debug.Log("c");
//        //}



//    }
//    //public void CreateGrenade()
//    //{
//    //            Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
//    //            Debug.Log($"{i}");
//    //            StartCoroutine("CreateDelay");
//    //            i++;
//    //}
//    //private void OnTriggerEnter(Collider other)
//    //{
//    //while (i < objList.Length)
//    //{
//    //    //캐비넷이 손에 닿을때마다 캐비넷 자식인 무기들을 활성화?
//    //    if (other.gameObject.name.Contains("Hand"))
//    //    {
//    //        objList[i].gameObject.SetActive(true);
//    //        //GameObject child = transform.GetChild(i).gameObject;
//    //        //child.SetActive(true);
//    //        i++;
//    //    }
//    //}
//    //}
//    //private void OnCollisionEnter(Collision collision)
//    //{
//    //    if (collision.gameObject.name.Contains("Hand"))
//    //    {
//    //        if (transform.GetChild(1) == null && i < 3)
//    //        {
//    //            Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
//    //            Debug.Log($"{i}");
//    //            i++;

//    //        }
//    //    }
//    //}
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Cabinet_B : MonoBehaviour
{
    [SerializeField]
    List<GameObject> objList = new List<GameObject>();
    [SerializeField]
    GameObject grenadePrefabs;
    public XRSocketInteractor sci;

    private bool getGrenade = false;
    private int i = 0;
    private int size = 5;
    //private int grenadenum=3;
    //    // Start is called before the first frame update
    void Start()
    {
        Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation).GetComponent<XRGrabInteractable>();
    }

    //    // Update is called once per frame
    void Update()
    {
        //Debug.Log("A");

        //CoroutineSet();



    }
    public void createGren()
    {
        if (size > 0)
        {
            XRGrabInteractable r;
            r = Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation).GetComponent<XRGrabInteractable>();
            sci.startingSelectedInteractable = r;
            //Debug.Log(size);
            size--;
        }
        //XRGrabInteractable r;
        //r = Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation).GetComponent<XRGrabInteractable>();
        //Debug.Log(r);
        //sci.startingSelectedInteractable = r;
    }

    void CoroutineSet()
    {
        getGrenade = false;
        if (!getGrenade)
        {
            StartCoroutine(CreateDelay());
        }

    }

    IEnumerator CreateDelay()
    {
        Debug.Log("B");
        yield return new WaitForSeconds(3.0f);
        getGrenade = true;

        if (getGrenade)
        {
            Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
            Debug.Log("c");
            getGrenade = false;
        }

        //if (gameObject.transform.Find("Grenade_B (3) Variant(Clone)") == null)
        //{
        //Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
        //Debug.Log("c");
        //}



    }
    //public void CreateGrenade()
    //{
    //            Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
    //            Debug.Log($"{i}");
    //            StartCoroutine("CreateDelay");
    //            i++;
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //while (i < objList.Length)
    //{
    //    //캐비넷이 손에 닿을때마다 캐비넷 자식인 무기들을 활성화?
    //    if (other.gameObject.name.Contains("Hand"))
    //    {
    //        objList[i].gameObject.SetActive(true);
    //        //GameObject child = transform.GetChild(i).gameObject;
    //        //child.SetActive(true);
    //        i++;
    //    }
    //}
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name.Contains("Hand"))
    //    {
    //        if (transform.GetChild(1) == null && i < 3)
    //        {
    //            Instantiate(grenadePrefabs, this.transform.position, this.transform.rotation);
    //            Debug.Log($"{i}");
    //            i++;

    //        }
    //    }
    //}
}
