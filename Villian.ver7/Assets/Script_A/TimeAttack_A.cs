using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeAttack_A : MonoBehaviour
{
    [SerializeField] float setTime = 60.0f;
    [SerializeField] Text countdewnText;

     //private GameObject Gun;
     //private GameObject Sword;
     //private GameObject Grenade;

    public GameObject ControllerUI;

    public List<GameObject> Weapons = new List<GameObject>();



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerUI.activeSelf == false) //// 컨트롤 UI가 꺼지면 시간 카운트 시작
        {
            setTime -= Time.deltaTime;
            countdewnText.text = Mathf.Round(setTime).ToString();
        }
            
            

        Debug.Log(Weapons.Count);

        if (setTime <= 0) // 시간이 0이면 씬매니저 함수 실행
        {
            setTime = 0;
           SceneManager_A();
        }
    }

    void SceneManager_A()
    {
        Debug.Log(Weapons.Count);

        
        if (Weapons[0] == null || Weapons[1] == null || Weapons[2] == null)
        {
            Debug.Log("A");
            SceneManager.LoadScene("City_scene_summer123");
        }
        else
        {
            SceneManager.LoadScene("Office");
        }

        // 시간이 0초이거나 무기를 1개 이상 찾았을 경우 넘어감
        //if(setTime == 0 && Weapons.Count <= 2)
        //{
        //    Debug.Log("A");
        //    SceneManager.LoadScene("Test");
        //}

        //if (setTime == 0 && Weapons.Count == 3 ) //1
        //{
        //    Debug.Log("B");
        //    SceneManager.LoadScene("Office");
        //}




        //if (setTime <= 0 && gameObject.GetComponent<BoxCollider>().enabled == false)
        //{
        //    {
        //        SceneManager.LoadScene("Office");
        //    }
        //}

        //else
        //{
        //    SceneManager.LoadScene("Office");
        //}

        //if (setTime <= 0 && gameObject.activeSelf == true)
        //{
        //    SceneManager.LoadScene("Test");
        //}

        //else if (setTime <= 0)
        //{
        //    SceneManager.LoadScene("Office");
        //}
    }


}


