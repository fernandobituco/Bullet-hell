using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;

    [Header("Paineis e Menu")]
    public GameObject pause;

    public GameObject PrincipalCanvas;
    public string cena;

    

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseScreen();
        }
    }

    public void PauseScreen()
    {
        if(isPaused)
        {
            isPaused = false;
            pause.SetActive(false);
            Time.timeScale = 1;
        }else 
        {
            isPaused = true;
            pause.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void BackToMenu(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

     public void BackToGame()
    {
        isPaused = false;
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
