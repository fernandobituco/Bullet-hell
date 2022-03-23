using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    private static int enemies;
    private static int enemiesValue;
    private static int random;
    private static float distance = 4.5f;

    void Start()
    {
        enemies = 0;
        enemiesValue = 0;
    }
    public int GenerateEnemies(int level)
    {
        while (enemiesValue < level)
        {
            random = Random.Range(1,5);
            while (enemiesValue + random > level)
            {
                random--;
            }
            switch (random)
            {
                case 1:
                    Spawn(enemy1);
                    break;
                case 2:
                    Spawn(enemy2);
                    break;
                case 3:
                    Spawn(enemy3);
                    break;
                case 4:
                    Spawn(enemy4);
                    break;
            }
        }
        return enemies;
    }

    private static void Spawn(GameObject enemy)
    {
        enemies++;
        enemiesValue += random;
        random = Random.Range(0, 360);
        Instantiate(enemy, new Vector3(Mathf.Sin(random) * distance, Mathf.Cos(random) * distance, 0), Quaternion.identity);
    }
    
}
