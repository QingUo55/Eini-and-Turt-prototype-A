using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EiniControl : PlayerMovement
{
    public override void Parameters()
    {
        groundDistance = 0.001f;
        sprintSpeed = 25f;
        maxSpeed = 15f;
        acceleration = 15f;
        deceleration = 0;
        gravityValue = 31f;
        maxJumpSpeed = 20f;
        jumpSpeed = 25f;
        jumpAcceleration = 50f;
        jumpHeigth = 8f;
        airTime = 0.5f;
    }

    public override void Gravity()
    {
        if (GameHandler.Instance.ActiveCharacter != Character.Eini)
        {
            return;
        }
        base.Gravity();
    }

    public override void GroundedMovement(float direction)
    {
        if (GameHandler.Instance.ActiveCharacter != Character.Eini)
        {
            return;
        }
        base.GroundedMovement(direction);
    }

    public override void Falling()
    {
        if (GameHandler.Instance.ActiveCharacter != Character.Eini)
        {
            return;
        }
        base.Falling();
    }

    public override void Jump()
    {
        if (GameHandler.Instance.ActiveCharacter != Character.Eini)
        {
            return;
        }
        base.Jump();
    }

    public override void stopMovement(float direction)
    {
        if (GameHandler.Instance.ActiveCharacter != Character.Eini)
        {
            return;
        }
        base.stopMovement(direction);
    }
}

