using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public CharacterMovement characterMovement;

    void FixedUpdate()
    {
        characterMovement.MoveUpdate();
    }

}
