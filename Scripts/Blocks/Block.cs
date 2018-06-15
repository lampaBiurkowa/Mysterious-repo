using Godot;
using System;

public class Block : StaticBody2D
{
    protected bool isCollidable;
    protected string texturePath;
    
    public string TexturePath
    {
        get
        {
            return texturePath;
        }
        set
        {
            texturePath = value;
        }
    }

    public bool IsCollidable
    {
        get
        {
            return isCollidable;
        }
        set
        {
            isCollidable = value;
        }
    }

    public override void _Ready()
    {}

    public void handleCollidable()
    {
        CollisionShape2D collision = (CollisionShape2D)GetNode("CollisionShape2D");
        if (isCollidable)
            collision.Disabled = false;
        else
            collision.Disabled = true;
    }
}