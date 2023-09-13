using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MovementBase
{
    public override void EnterState(PlayerMovement movement)
    {
        movement.anim.SetBool("walk", true);
    }
    public override void UpdateState(PlayerMovement movement)
    {
        if (movement.moveDirection.magnitude < 0.1f)
            ExitState(movement, movement.idlee);
    }
    void ExitState(PlayerMovement movement,MovementBase state)
    {
        movement.anim.SetBool("walk", false);
        movement.SwitchState(state);
    }
}
