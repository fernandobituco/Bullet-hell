using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hp=10;
    public Transform child;
    public HealthBar enemyHP;
    public ParticleSystem spawnParticles;
    public ParticleSystem enemyGun;
    public ParticleSystem deathParticles;
    private bool alive = false;

     public AudioSource audioSourceDeathEnemy;

    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(startShooting());
        enemyHP.MaxHealth(hp);
    }

    IEnumerator startShooting()
    {
        yield return new WaitForSeconds(3);
        alive = true;
        enemyGun.Play();
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        spawnParticles.Stop();
    }

    void Update()
    {
        transform.right = GameObject.Find("Player").GetComponent<Transform>().position - transform.position;
        child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -transform.rotation.z);
    }

    void OnParticleCollision(GameObject other)
    {
        if (alive)
        {
            hp--;
            enemyHP.Health(hp);
            if (hp == 0)
            {
                StartCoroutine(Death());
            }
        }
    }
    
    IEnumerator Death()
    {
        enemyGun.Stop();
        deathParticles.Play();
        audioSourceDeathEnemy.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        LevelManager.KillEnemy();
    }
}
