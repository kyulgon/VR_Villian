using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyItem_A : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Sword;
    public GameObject Granade;

    public GameObject preGun;
    public GameObject preSword;
    public GameObject preGranade;

    private void Awake()
    {
        if (Gun == null)
        {
            DontDestroyOnLoad(preGun);
        }

        if (Sword == null)
        {
            DontDestroyOnLoad(Sword);
        }

        if (Granade == null)
        {
            DontDestroyOnLoad(Sword);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
