using Godot;
using System;
using System.Collections.Generic;

abstract class Block:Sprite
{
    protected int subId;
    protected bool isCollidable = true;
    public Block(int subId)
    {
        this.subId = subId;
    }

    protected abstract void setTextureBasedOnSubId(); 
}