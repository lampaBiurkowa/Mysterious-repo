using Godot;
using System;
<<<<<<< HEAD:Scripts/Block.cs

abstract public class Block : StaticBody2D
=======
using System.Collections.Generic;

abstract class Block
>>>>>>> no message:Scripts/Blocks/Block.cs
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
