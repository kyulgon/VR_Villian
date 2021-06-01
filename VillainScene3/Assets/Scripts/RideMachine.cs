using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RideMachine : MonoBehaviour
{
    public Image fadeImage;


    void Start()
    {
       
      
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Portal")
        {
            StartCoroutine(waitTime());
            StartCoroutine(FadeIn());
        }
    }


IEnumerator FadeIn()
    {
        Color startColor = fadeImage.color;

        for (int i = 0; i < 100; i++)
        {
            startColor.a = startColor.a + 0.01f;
            fadeImage.color = startColor;
            yield return new WaitForSeconds(0.01f);
        }        
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
