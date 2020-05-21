using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{

    public List<BaseWeapons> weaponsPrefabs;


    public BaseWeapons GetWeapons(int weaponsId)
    {
        GameObject weapon = Instantiate(weaponsPrefabs[weaponsId].gameObject);
        return weapon.GetComponent<BaseWeapons>();
    }
}
