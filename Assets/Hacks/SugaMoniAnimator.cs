using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugaMoniAnimator : MonoBehaviour, IControllable
{

    SugaMoni sugaMoni;
    Animator animator;

    public InputToken InputToken { get; set; }

    private void Start()
    {
        sugaMoni = GetComponent<SugaMoni>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", sugaMoni.Grounded);
        animator.SetFloat("Speed", sugaMoni.HMomentum == 0f ? 0f : 1f);
        animator.SetBool("Duck", InputToken.Vertical < -.5f && InputToken.AbsHor == 0f && sugaMoni.Grounded);
    }
}
