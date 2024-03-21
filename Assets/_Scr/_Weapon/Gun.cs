using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBehavior
{
    [SerializeField] private float vibrationIntensity;
    public Transform firePos;
    public GameObject ammo;
    public int maxAmmo;
    protected int currentAmmo;
    private PlayerController player;

    private void Awake()
    {
        player = transform.root.GetComponent<PlayerController>();
        InitGun();
    }

    protected virtual void InitGun()
    {
        currentAmmo = maxAmmo;
    }

    protected virtual void Shoot()
    {
        player.Shoot(vibrationIntensity);
    }
}