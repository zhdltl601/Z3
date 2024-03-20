using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBehavior
{
    protected Vector3 mousePos;
    public Transform firePos;
    public Transform handTrm;
    public GameObject ammo;
    public int maxAmmo;
    protected int currentAmmo;
    private PlayerController player;

    private void Awake()
    {
        //OnM1 += Ming;
        //OnM2 += Ming2;
        player = transform.root.GetComponent<PlayerController>();
        InitGun();
    }

    private void Update()
    {
        GetMouseZVec();
    }

    private void GetMouseZVec()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,
            -mousePosition.z));
    }

    protected virtual void InitGun()
    {
        currentAmmo = maxAmmo;
    }

    protected virtual void Shoot()
    {
        player.Shoot();
    }
}