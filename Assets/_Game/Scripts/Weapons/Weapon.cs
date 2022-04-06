using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;

    private float fireTimer;
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButton(0) && CanShoot())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        fireTimer = Time.time + fireRate;
        Instantiate(bullet, barrel.position, barrel.rotation);

        anim.SetTrigger("Fire");
    }

    private bool CanShoot() => Time.time > fireTimer;
}
