using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtControl : PlayerMovement
{
    public override void Parameters()
    {
        if (GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            return;
        }
        base.Parameters();
    }

    public override void Gravity()
    {
        if (GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            return;
        }
        base.Gravity();
    }

    public override void GroundedMovement(float direction)
    {
        if(GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            return;
        }
        base.GroundedMovement(direction);
    }

    public override void Falling()
    {
        if (GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            return;
        }
        base.Falling();
    }

    public override void Jump()
    {
        if (GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            return;
        }
        base.Jump();
    }

    public override void stopMovement(float direction)
    {
        if (GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            return;
        }
        base.stopMovement(direction);
    }
}
