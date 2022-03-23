using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private JoysticksActions joystickActions;
    [SerializeField] private int speed = 5;
    private int hp = 10;
    public HealthBar hpBar;
    public ParticleSystem deathParticles;
    public CameraHit cam;
    public GameObject gun;
    public AudioSource audioSourceDeath;
    public AudioSource audioSourceHit;

    void Awake()
    {
        joystickActions = new JoysticksActions();
    }

    void OnEnable()
    {
        joystickActions.Enable();
    }
    void OnDisable()
    {
        joystickActions.Disable();
    }

    void Start()
    {
        hpBar.MaxHealth(hp);
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float joystickPosx = joystickActions.Player.Move.ReadValue<Vector2>().x * speed * Time.deltaTime;
        float joystickPosy = joystickActions.Player.Move.ReadValue<Vector2>().y * speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + joystickPosx, transform.position.y + joystickPosy, 0);
    }

    void OnParticleCollision(GameObject other)
    {
        hp--;
        cam.TakeHit();
        hpBar.Health(hp);
        if (hp == 0)
        {
            StartCoroutine(Death());           
        }
        
        else
        {
            if(hp > 0)
            {          
                audioSourceHit.Play();
            }           
        }
    }

    IEnumerator Death()
    {
        gun.SetActive(false);
        deathParticles.Play();
        audioSourceDeath.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    
}
