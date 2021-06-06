using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet_B : MonoBehaviour
{
    [SerializeField]
    GameObject[] objList;
    //    //public GameObject obj1;
    //    //public GameObject obj2;
    //    //public GameObject obj3;
    //    //public GameObject obj4;
    //    //public GameObject obj5;
    //    //public GameObject obj6;
    //    //public GameObject obj7;
    //    //public GameObject obj8;
    //    //public GameObject obj9;
    //    //public GameObject obj10;
    private int i = 1;
    //private int grenadenum=3;
//    // Start is called before the first frame update
    void Start()
    {
        //bjList = GetComponentsInChildren<GameObject>();
    }

//    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{objList.Length}");
    }
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    while (i < objList.Length)
    //    {
    //        if (other.gameObject.name.Contains("Hand"))
    //        {
    //            objList[i].gameObject.SetActive(true);
    //            i++;
    //        }
    //    }
    //}
}
