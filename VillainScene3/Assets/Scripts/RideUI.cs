using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RideUI : MonoBehaviour
{
    [SerializeField] private Button button;

    public GameObject playerPosition;
    public GameObject targetPoint;
    

    //public Image fadeImage;

    private void Start()
    {
        

    }


    void Update()
    {
        button.onClick.AddListener(() =>
        {
            playerPosition.transform.LookAt(targetPoint.transform);
            playerPosition.transform.position = Vector3.MoveTowards(playerPosition.transform.position, targetPoint.transform.position, 0.1f);
        });
    }

    //IEnumerator FadeIn()
    //{
    //    Color startColor = fadeImage.color;

    //    for (int i = 0; i < 100; i++)
    //    {
    //        startColor.a = startColor.a + 0.01f;
    //        fadeImage.color = startColor;
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //}
}
