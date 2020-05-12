using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator anim;
    public CharacterMovement characterMovement;
    public CharacterStatus characterStatus;
    
  

    // Update is called once per frame
    public void AnimationUpdate()
    {
        anim.SetBool("Aim", characterStatus.isAiming);

        if (!characterStatus.isAiming)
            AnimationNormal();
        else
            AnimationAiming();
    }

    void AnimationNormal()
    {
        anim.SetFloat("Vertical", characterMovement.moveAmount, 0.15f, Time.deltaTime);
    }

    void AnimationAiming()
    {
        float v = characterMovement.vertical;
        float h = characterMovement.horizontal;

        anim.SetFloat("Vertical", v, 0.15f, Time.deltaTime);
        anim.SetFloat("Horizontal", h, 0.15f, Time.deltaTime);
    }
}
