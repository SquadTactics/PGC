using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGuns : MonoBehaviour
{
    public int InitialAmmo;
    public int CapacityAmmo;
    public int BulletComb;
    public float FireRate;
    public AudioClip[] GunAudioClip;
    public Bullet GunBullet;
    public Transform SpawnBullet;

    private Animator AnimGuns;
    private float TempFire;
    public bool CanFire = true;
    // Start is called before the first frame update
    protected void Start()
    {
        BulletComb = InitialAmmo;
        AnimGuns = GetComponentInChildren<Animator>();
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
            if(AnimGuns != null)
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
            BulletComb--;
            if (AnimGuns != null)
            {
                AnimGuns.SetTrigger("Fire");
            }
            TempFire = 0;
        }
    }

    protected abstract void OnShoot();
    protected abstract void OnReload();
}
