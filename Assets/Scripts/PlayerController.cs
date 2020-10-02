using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseEntity
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    protected override void Update()
    {
        // Controls the player left right
        var x = 0;
        if (Input.GetKey(this.Left))
        {
            x--;
        }
        if (Input.GetKey(this.Right))
        {
            x++;
        }
        this.XVelocityGoal = this.VelocityLimit.x * x;

        // Controls jump
        if (Input.GetKeyDown(this.Up))
        {
            this.Jump();
        }
    }
}
