using Godot;
using System;
using System.Collections.Generic;
abstract class Block
{
    private Vector2 size;
    private string code;
    private bool isCollidable;

    public Vector2 Size
    {
        get
        {
            return size;
        }
    }

    //?! ?!?!? ?!?!?!?!?!?!?!?!?!?!?!?!??!?!?!?!
    public Block(string code)
    {
        this.code=code;
        size=new Vector2(64f,64f);
    }
}