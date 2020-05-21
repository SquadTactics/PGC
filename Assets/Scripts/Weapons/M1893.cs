using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1893 : BaseWeapons
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    { 
        Instantiate(bulletProjectil[0], transform.position, transform.rotation);
    }

    protected override void Reload()
    {
       
    }
}
