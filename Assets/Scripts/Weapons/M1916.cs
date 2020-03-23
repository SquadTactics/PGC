using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1916 : BaseGuns
{
    //private AudioSource GunSounds;

    new void Start()
    {
        base.Start();
       // GunSounds = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    protected override void OnReload()
    {
        //GunSounds.clip = GunAudioClip[1];
        //GunSounds.Play();
    }

    protected override void OnShoot()
    {
        if (BulletComb > 0 && CanFire)
        {
            Instantiate(GunBullet, SpawnBullet.transform.position, SpawnBullet.transform.rotation);
            //GunSounds.clip = GunAudioClip[0];
            //GunSounds.Play();
        }
    }
}
