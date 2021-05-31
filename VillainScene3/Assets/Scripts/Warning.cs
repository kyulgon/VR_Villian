using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[System.Serializable]
//public class Dialogue
//{
//    [TextArea]
//    public string dialogue;
//}

public class Warning : MonoBehaviour
{
    public GameObject warning;
    public GameObject bossMonster;

    [SerializeField] private Image Dialogubox;
    [SerializeField] private Text txt_Dialogu1;
    [SerializeField] private Text txt_Dialogu2;

    private bool isDialogue = false;
    //private int count = 0;

    //[SerializeField] private Dialogue[] dialogue;



    void Start()
    {
        StartCoroutine(WarningUI());
    }

    void Update()
    {
       
    }

    IEnumerator WarningUI()
    {
        yield return new WaitForSeconds(3f);
        warning.SetActive(false);
        bossMonster.GetComponent<Rigidbody>().useGravity = true;
        
        yield return new WaitForSeconds(2f);
        //ShowDialogue();
        isDialogue = true;

        if (isDialogue)
        {
            Dialogubox.gameObject.SetActive(true);
            txt_Dialogu1.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            txt_Dialogu1.gameObject.SetActive(false);
            txt_Dialogu2.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            txt_Dialogu2.gameObject.SetActive(false);
            Dialogubox.gameObject.SetActive(false);
        }
       

    }

    //public void ShowDialogue()
    //{
    //    Onoff(true);
    //    count = 0;
    //    NextDialogue();
    //}

    //private void Onoff(bool _flag)
    //{
    //    Dialogubox.gameObject.SetActive(_flag);
    //    txt_Dialogu.gameObject.SetActive(_flag);

    //    isDialogue = _flag;
    //}


    //private void NextDialogue()
    //{
    //    txt_Dialogu.text = dialogue[count].dialogue;
    //    count++;
    //}
}
