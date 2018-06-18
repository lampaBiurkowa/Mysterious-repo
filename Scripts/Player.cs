using Godot;
using System;

public class Player : KinematicBody2D
{
    private const int SPEED = 1;
    private const int FALL_SPEED = 2;
    private const int EXTRA_SPEED = 10;
    private const int JUMP_POWER = 10;
    private const int JUMP_DURATION = 10;
    private const int DISPLAY_Y = 1080;
    private bool jumping;
    private int jumpCounter;

    public void HandleJump()
    {
        if (Input.IsActionJustPressed("jump")||jumping==true)
        {
            if (!jumping)
                jumping = true;
            int jumpHeight = JUMP_POWER / jumpCounter;
            MoveAndCollide(new Vector2(0,-jumpHeight));
            jumpCounter++;
            if (jumpCounter == 10)
            {
                jumping = false;
                jumpCounter = 1;
            }
        }
    }

    public void HandleMove()
    {
        MoveAndCollide(new Vector2(SPEED,0));
    }

    public void HandleFall()
    {
        if(!jumping)
            MoveAndCollide(new Vector2(0,FALL_SPEED));
    }

    public bool lost()
    {
        return (isFallen()||isCrashed());
    }

    public override void _Ready()
    {
        jumping = false;
        jumpCounter = 1;
    }

    public override void _Process(float delta)
    {}

    private bool isFallen()
    {
        if (this.GetPosition().y > DISPLAY_Y)
            return true;
        return false;
    }

    private bool isCrashed()
    {
        return false;
    }

}
