using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapons : MonoBehaviour
{
    public float fireRate;
    public float gunDamage;
    public float gunDistanceShoot;
    public int bulletComb;
    public int bulletInGun;

    public AudioClip []gunsAudioClip;
    public List<Bullet> bulletProjectil;
    public Transform spawnBullet;

    private float currentFireRate;
    private bool canShoot = true;

    private AudioSource gunsAudioSource;

    protected void Start()
    {
        gunsAudioSource = GetComponent<AudioSource>();
        bulletInGun = bulletComb;
    }

    // Update is called once per frame
    protected void Update()
    {
        currentFireRate += Time.deltaTime;
        if (currentFireRate > fireRate)
        {
            canShoot = true;
        }

        else
        {
            canShoot = false;
        }
    }

   public void OnShoot()
    {
        if ( bulletInGun > 0 && canShoot)
        {
            Shoot();
            bulletInGun--;
            gunsAudioSource.clip = gunsAudioClip[0];
            gunsAudioSource.Play();
            currentFireRate = 0;
        }

        if (bulletInGun == 0)
        {
            gunsAudioSource.clip = gunsAudioClip[2];
            gunsAudioSource.Play();
        }
    }

    public void OnReload()
    {
        if (bulletInGun < bulletComb)
        {
            Reload();
            bulletInGun = 0;
            bulletInGun = bulletComb;
            gunsAudioSource.clip = gunsAudioClip[1];
            gunsAudioSource.Play();
        }
    }

    protected abstract void Shoot();
    protected abstract void Reload();
}
