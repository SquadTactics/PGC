using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1916 : BaseGuns
{
    //private AudioSource GunSounds;
    public GameObject Mira;
    private Mira ScriptMira;
    new void Start()
    {
        base.Start();
        ScriptMira = Mira.GetComponent<Mira>();
       
    }
    // Update is called once per frame
    new void Update()
    {
        base.Update();

    }

    protected override void OnReload()
    {
        
    }

    protected override void OnShoot()
    {
        if (BulletComb > 0 && CanFire)
        {
            //Instantiate(GunBullet, SpawnBullet.transform.position, SpawnBullet.transform.rotation);
            Vector3 PosBala = new Vector3(0, 0, 1.5f);
            Instantiate(GunBullet, Camera.main.transform.TransformPoint(PosBala), SpawnBullet.transform.rotation);

        }
    }

    protected override void ShowSight()
    {
        Mira.SetActive(true);
    }

    protected override void SetSpread(float Spread)
    {
        ScriptMira.SetTamMira(Spread);
    }
    protected override void RemoveSight()
    {
        Mira.SetActive(false);
    }
}
