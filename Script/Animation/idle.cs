using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : MovementBase
{
    public override void EnterState(PlayerMovement movement)
    {
       
    }
    public override void UpdateState(PlayerMovement movement)
    {
        if (movement.moveDirection.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.W)) movement.SwitchState(movement.walk);

        }
    }
}
