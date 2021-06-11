using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive_A : MonoBehaviour
{
    public GameObject ControllerUI;

    public GameObject Dialog;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllerUI.activeSelf == false)
        {
            Dialog.SetActive(true);
        
        }

        //OnClickDialogButton();
    }

    //public void OnClickDialogButton()
    //{
    //    if (Dialog.activeSelf == true)
    //    {
    //        //Destroy(Dialog);
    //        Dialog.SetActive(false);
    //    }
    //}

    //    public void ButtonOnClick() 
    //    {
    //        if(Dialog == null)
    //        {
    //            Instantiate(Dialog);
    //}        Debug.Log("ddddd");
    //    }


}
