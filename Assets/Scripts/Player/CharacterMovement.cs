using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private float moveAmount;

    private Animator characterAnimator;

    // Update is called once per frame

    private void Start()
    {
        characterAnimator = gameObject.GetComponent<Animator>();
    }
    public void MoveUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));

        characterAnimator.SetFloat("vertical", vertical, 0.15f, Time.deltaTime);
    }
}
