using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class towerCtrl : MonoBehaviour
{
    int HP = 100;
    public Slider hpSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(float amount)
    {
        HP -= (int)(amount);
        hpSlider.value = HP;
        
        if (HP <= 0)
        {
            Debug.Log("towerhp_0");
            Time.timeScale = 0;
            //pauseCanvas.gameObject.SetActive(false);
            //3s.
            SceneManager.LoadScene("City_scene_summer123");
            
        }
    }

}
