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
    
    public void createBlock(int subid){}

    public override void _Ready()
    {
        
    }
}
