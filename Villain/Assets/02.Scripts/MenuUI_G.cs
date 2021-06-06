using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI_G : MonoBehaviour
{
    public GameObject showDie; // boss 오브젝트
    public Text DieText; 

    public GameObject menuOffset;
    private bool ShowDie;

    void Start()
    {
        ShowDie = false;
    }

    public void BossDie()
    {
        showDie.SetActive(true);
        Invoke("Wait3sec", 3f);
    }

    void Wait3sec()
    {
        showDie.SetActive(false);
    }

    void Update()
    {
        if(menuOffset != null)
        {
            this.transform.position = menuOffset.transform.position;
            this.transform.rotation = menuOffset.transform.rotation;
        }
    }
}
