using Godot;
using System;

public class Player : KinematicBody2D
{
    const int SPEED = 1;
    const int FALL_SPEED = 2;
    const int EXTRA_SPEED = 10;
    const int JUMP_POWER = 30;
    bool jumping = false;

    public void HandleJump()
    {
        if (Input.IsActionJustPressed("jump"))
        {
            jumping = true;
            MoveAndCollide(new Vector2(0,-JUMP_POWER));
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

    public override void _Ready()
    {}

    public override void _Process(float delta)
    {}
}
