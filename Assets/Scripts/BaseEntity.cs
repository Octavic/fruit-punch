using UnityEngine;
using System.Collections.Generic;

public abstract class BaseEntity : MonoBehaviour
{
    // Movement config
    public Vector2 Velocity;
    public float XVelocityGoal;

    public float VelocityLimit;
    public float XVelocityLerp;

    public float JumpSpeed;
    public float Gravity;

    /// <summary>
    /// For terrain and airborne-ness
    /// </summary>
    public bool IsAirbone
    {
        get
        {
            return this.onTerrains.Count == 0;
        }
    }
    private HashSet<Terrain> onTerrains = new HashSet<Terrain>();

    public void OnEnterTerrain(Terrain terrain)
    {
        this.onTerrains.Add(terrain);
    }
    public void OnLeaveTerrain(Terrain terrain)
    {
        this.onTerrains.Remove(terrain);
    }

    public Rigidbody2D rgbd2
    {
        get
        {
            return this.GetComponent<Rigidbody2D>();
        }
    }

    public void Jump()
    {
        //if (!this.IsAirbone)
        //{
        //    this.Velocity = new Vector2(
        //        this.Velocity.x,
        //        this.JumpSpeed
        //    );
        //}
        this.Velocity = new Vector2(
            this.Velocity.x,
            this.JumpSpeed
        );
    }

    protected virtual void Update()
    {

    }

    /// <summary>
    /// Called once per frame
    /// </summary>
    protected virtual void FixedUpdate()
    {
        // Modify movement 
        var movementX = FloatUtils.Lerp(this.Velocity.x, this.XVelocityGoal, this.XVelocityLerp);
        if (Mathf.Abs(movementX) < 0.0001f)
        {
            movementX = 0;
        }
        this.Velocity = new Vector2(movementX, this.Velocity.y + this.Gravity);

        // limit the movement speed
        this.Velocity = new Vector2(
            Mathf.Clamp(this.Velocity.x, -this.VelocityLimit, this.VelocityLimit),
            Mathf.Max(this.Velocity.y, -this.VelocityLimit)
        );

        // Move
        this.rgbd2.MovePosition((Vector2)this.transform.position + this.Velocity * Time.deltaTime);
    }
}
