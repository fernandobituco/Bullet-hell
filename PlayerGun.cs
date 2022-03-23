using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private JoysticksActions joystickActions;
    private ParticleSystem gun;
    public AudioSource audioSourceLaser;

    
    void Awake()
    {
        joystickActions = new JoysticksActions();
        gun = GetComponent<ParticleSystem>();
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
        joystickActions.Player.Aim.started += _ => StartShooting();
        joystickActions.Player.Aim.canceled += _ => StopShooting();
        joystickActions.Player.Aim.performed += _ => AimGun();
    }

    private void StopShooting()
    {
        gun.Stop();
        audioSourceLaser.Stop();
    }

    private void StartShooting()
    {
       
        gun.Play();
        audioSourceLaser.Play();
        //SoundManagerScript.PlaySound("lasershoot");
    }

    private void AimGun()
    {
        transform.right = joystickActions.Player.Aim.ReadValue<Vector2>();
    }
}
