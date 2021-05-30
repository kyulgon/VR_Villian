using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
}

public class Warning : MonoBehaviour
{
    public GameObject warning;
    public GameObject machine;

    [SerializeField] private Image Dialogubox;
    [SerializeField] private Text txt_Dialogu;

    private bool isDialogue = false;
    private int count = 0;

    [SerializeField] private Dialogue[] dialogue;



    void Start()
    {
        StartCoroutine(WarningUI());
    }

    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialogue.Length)
                {
                    NextDialogue();
                }
                else
                {
                    Onoff(false);
                }
            }
        }
    }

    IEnumerator WarningUI()
    {
        yield return new WaitForSeconds(3f);
        warning.SetActive(false);
        machine.GetComponent<Rigidbody>().useGravity = true;
    }

    public void ShowDialogue()
    {
        Onoff(true);
        count = 0;
        NextDialogue();
    }

    private void Onoff(bool _flag)
    {
        Dialogubox.gameObject.SetActive(_flag);
        txt_Dialogu.gameObject.SetActive(_flag);

        isDialogue = _flag;
    }


    private void NextDialogue()
    {
        txt_Dialogu.text = dialogue[count].dialogue;
        count++;
    }
}
