using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_G : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject playerGameobject;
    public Text hpText;

    public bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        if(!isGameOver)
        {
            hpText.text = "HP : " + (int)playerGameobject.GetComponent<MachineController_G>().hp;
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("City_scene_autumn");
    }
}
