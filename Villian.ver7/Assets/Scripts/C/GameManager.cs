using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI text;
   
    public int Count = 5;

    private static GameManager instance = null;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    void Start()
    {
        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log($"GameManager : {Count}");
        text.text ="x" + Count.ToString();

    }
}
