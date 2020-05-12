using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public CharacterAnimation characterAnimation;
    public CharacterInput characterInput;

    void Update()
    {
        characterMovement.MoveUpdate();
        characterAnimation.AnimationUpdate();
        characterInput.InputUpdate();
    }

}
