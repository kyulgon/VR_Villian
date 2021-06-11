using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCtrl_C : MonoBehaviour
{
    public Image[] HeartImages;
    private int index = 0;
    void Start()
    {

    }

    void Update()
    {

    }
    public void PlayerHP()
    {
        Debug.Log("Test1");
        if (index < HeartImages.Length)
        {
            HeartImages[index].gameObject.SetActive(false);

            
            index++;

        }
        else
        {
            Time.timeScale = 0;
            //pauseCanvas.gameObject.SetActive(false);
            //3s.
            SceneManager.LoadScene("City_scene_summer123");
        }
    }
}
