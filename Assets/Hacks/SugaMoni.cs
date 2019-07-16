using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugaMoni : Mobile, IControllable
{
    public InputToken InputToken { get; set; }

    public float airControl = .2f;
    public float speed = 5f;
    public float jumpForce = 9f;

    public bool Disable { get; set; } = false;

    public event System.Action OnJump;

    int airJump = 1;

    int cyoteTime = 5;

    new void Start()
    {
        base.Start();
        var spawn = FindObjectOfType<Spawn>();
        if (spawn)
            transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        if(Disable) // dirty hack, dont do it like this
        {
            HMomentum = 0f;
            base.FixedUpdate();
            return;
        }

        cyoteTime--;
        if (Grounded)
        {
            HMomentum = InputToken.Horizontal * speed;
            airJump = 1;
            UpdateFacing();
            cyoteTime = 5;
        }
        else
            HMomentum = HMomentum * (1f - airControl) + InputToken.Horizontal * speed * airControl;
        if (cyoteTime >= 0 && InputToken.Jump)
        {
            VMomentum = jumpForce;
            InputToken.ClearJump();
            OnJump();
        }
        else if(airJump > 0 && InputToken.Jump && (VMomentum <= 0f || VMomentum > 1f))
        {
            // the snippet works together with the input buffer to help you nail the air jump at the top of your arc
            VMomentum = jumpForce * .8f;
            InputToken.ClearJump();
            OnJump();
            HMomentum = InputToken.Horizontal * speed;
            airJump--;
            UpdateFacing();
        }
        base.FixedUpdate();

        Gravity = InputToken.HoldJump ? 18f : 30f;
    }

    void UpdateFacing()
    {
        if(InputToken.AbsHor > 0f)
        {
            FaceRight = InputToken.Horizontal > 0f;
        }
    }
}
