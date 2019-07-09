using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput : MonoBehaviour
{

    public InputToken Token { get; private set; }

    private void Start()
    {
        Token = new InputToken();
        foreach (var item in GetComponents<IControllable>())
        {
            item.InputToken = Token;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deadzone = .3f;
        var h = Input.GetAxis("Horizontal");
        if (Mathf.Abs(h) < deadzone)
            h = 0f;
        var v = Input.GetAxis("Vertical");
        if (Mathf.Abs(v) < deadzone)
            v = 0f;
        Token.SetDirection(new Vector2(h, v));

        if (Input.GetButtonDown("Jump"))
            Token.PressJump();
        if (Input.GetButtonDown("Fire1"))
            Token.PressAttack();
        if (Input.GetButtonDown("Fire3"))
            Token.PressSpecial();
        Token.HoldBlock = Input.GetButton("Fire2");
        Token.HoldJump = Input.GetButton("Jump");
    }
}
