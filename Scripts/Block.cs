using Godot;
using System;

abstract public class Block : StaticBody2D
{
    //private Sprite sprite; ?
    //private Texture texture; ?
    //private CollisionShape2D collision; ?
    private bool isCollidable;

    public override void _Ready()
    {
        //sprite = (Sprite)GetNode("Sprite"); ?
        //sprite.Texture = texture; ?
        //if(isCollidable) ?
        //    collision.Disabled=true; ?
        //else ?
        //    collision.Disabled=false; ?
    }
}
