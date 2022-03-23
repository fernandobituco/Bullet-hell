using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static int level = 1;
    public static int enemies;
    public EnemyGenerator enemyGenerator;
    public Text levelDisplay;
    public int maxLevel;
    public int lastLevel;
    void Awake()
    {
        level = PlayerPrefs.GetInt("LastLevel", 1);
        maxLevel = PlayerPrefs.GetInt("MaxLevel", 1);
        enemies = enemyGenerator.GenerateEnemies(level);
        levelDisplay.text = "Level: " + level.ToString();
    }

    public static void KillEnemy()
    {
        enemies--;
        if (enemies == 0)
        {
            NextLevel();
        }
    }

    private static void NextLevel()
    {
        level++;
        PlayerPrefs.SetInt("LastLevel", level);
        if (level > PlayerPrefs.GetInt("MaxLevel", 0))
        {
            PlayerPrefs.SetInt("MaxLevel", level);
        }
        SceneManager.LoadScene(1);
    }
}
