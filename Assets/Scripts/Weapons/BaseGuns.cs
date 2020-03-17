using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGuns : MonoBehaviour
{
    public int InitialAmmo;
    public int CapacityAmmo;
    public int Munition;
    public int BulletComb;
    public float FireRate;
    public AudioClip[] GunAudioClip;
    public Bullet GunBullet;
    public Transform SpawnBullet;

    private Animator AnimGuns;

    // Start is called before the first frame update
    protected void Start()
    {
        BulletComb = InitialAmmo;
        AnimGuns = GetComponentInChildren<Animator>();
    }

    protected void Update()
    {
        
    }

    public void Reload()
    {
        OnReload();
        if (Munition > 0 && BulletComb < CapacityAmmo)
        {
            if(AnimGuns != null)
            {
                AnimGuns.SetTrigger("Reload");
            }
            Munition -= CapacityAmmo;
            BulletComb = 0;
            BulletComb += CapacityAmmo;
        }
    }

    public void Shoot()
    {
        OnShoot();
        if (BulletComb > 0)
        { 
            BulletComb--;
            if (AnimGuns != null)
            {
                AnimGuns.SetTrigger("Fire");
            }
        }
    }

    protected abstract void OnShoot();
    protected abstract void OnReload();
}
