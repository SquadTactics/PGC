﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGuns : MonoBehaviour
{
    public int InitialAmmo;
    public int CapacityAmmo;
    public int BulletComb;
    public float FireRate;
    public bool CanFire = true;
    public AudioClip[] GunAudioClip;
    public Bullet GunBullet;
    public Transform SpawnBullet;

    private Animator AnimGuns;
    private AudioSource WeaponAudioSource;
    private float TempFire;

    // Start is called before the first frame update
    protected void Start()
    {
        BulletComb = InitialAmmo;
        AnimGuns = GetComponentInChildren<Animator>();
        WeaponAudioSource = GetComponentInChildren<AudioSource>();
        TempFire = FireRate;
    }

    protected void Update()
    {

        TempFire += Time.deltaTime;
        if (TempFire > FireRate)
        {
            CanFire = true;
        }

        else
        {
            CanFire = false;
        }
    }

    public void Reload()
    {
        OnReload();
        if (BulletComb < CapacityAmmo)
        {           
            if (AnimGuns != null)
            {
                AnimGuns.SetTrigger("Reload");
            }
            BulletComb = 0;
            BulletComb = CapacityAmmo;
        }
    }

    public void Shoot()
    {
        OnShoot();
        if (BulletComb > 0 && CanFire)
        {
            WeaponAudioSource.clip = GunAudioClip[0];
            WeaponAudioSource.Play();
            BulletComb--;
            if (AnimGuns != null)
            {
                AnimGuns.SetTrigger("Fire");
            }
            TempFire = 0;
        }
    }
    public void DrawnSight()
    {
        ShowSight();
    }

    public void EraseSight()
    {
        RemoveSight();
    }

    public void TamMira(float Spread)
    {
        SetSpread(Spread);
    }

    protected abstract void SetSpread(float Spread);
    protected abstract void ShowSight();
    protected abstract void RemoveSight();
    protected abstract void OnShoot();
    protected abstract void OnReload();
}
