using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1895 : BaseWeapons
{
    // Start is called before the first frame update
   new void Start()
   {
        base.Start();
        bulletProjectil[0].distanceBullet = gunDistanceShoot;
        bulletProjectil[0].damageBullet = gunDamage;
    }

    // Update is called once per frame
   new void Update()
   {
        base.Update();
   }


    protected override void Shoot()
    { 
        Instantiate(bulletProjectil[0], spawnBullet.position, spawnBullet.rotation);
    }

    protected override void Reload()
    {

    }
}
