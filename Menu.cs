using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public GameObject plus;
    public GameObject minus;
    public Text leveltxt;
    private int playLevel;
    private int maxLevel;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", .5f);
        maxLevel = PlayerPrefs.GetInt("MaxLevel", 1);
        playLevel = PlayerPrefs.GetInt("LastLevel", 1);
        if (playLevel == maxLevel)
        {
            plus.SetActive(false);
        }
        if (playLevel == 1)
        {
            minus.SetActive(false);
        }
        leveltxt.text = playLevel.ToString();
    }
    public void LoadScene(int indexScene)
    {
        PlayerPrefs.SetInt("LastLevel", playLevel);
        SceneManager.LoadScene(indexScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
    }
    
    public void PlusLevel()
    {
        playLevel++;
        leveltxt.text = playLevel.ToString();
        if (playLevel == maxLevel)
        {
            plus.SetActive(false);
        }
        if (playLevel == 2)
        {
            minus.SetActive(true);
        }
    }

    public void MinusLevel()
    {
        playLevel--;
        leveltxt.text = playLevel.ToString();
        if(playLevel == 1)
        {
            minus.SetActive(false);
        }
        if(playLevel < maxLevel)
        {
            plus.SetActive(true);
        }
    }
}
