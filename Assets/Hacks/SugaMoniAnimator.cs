using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugaMoniAnimator : MonoBehaviour
{

    SugaMoni sugaMoni;
    Animator animator;

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
    }
}
