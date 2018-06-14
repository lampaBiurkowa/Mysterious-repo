using Godot;
using System;

public class Player : RigidBody2D
{
    const int SPEED = 1;
    const int EXTRA_SPEED = 10;
    const int JUMP_POWER = 30;

    public void Jump()
    {
        float x = this.GetPosition().x;
        float y = this.GetPosition().y;
        y -= JUMP_POWER;
        this.SetPosition(new Vector2(x,y));
    }

    public void Move()
    {
        float x = this.GetPosition().x;
        float y = this.GetPosition().y;
        x += SPEED;
        this.SetPosition(new Vector2(x,y));
    }

    public override void _Ready()
    {}

    public override void _Process(float delta)
    {}
}
