using Godot;
using System;

public class Player : KinematicBody2D
{
    private const int SPEED = 1;
    private const int FALL_SPEED = 2;
    private const int JUMP_POWER = 50;
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
        return isFallen(); //in case of crash event or sth...
    }

    public bool won(int finishX)
    {
        if (this.GetPosition().x >= finishX)
            return true;
        return false;
    }

    public override void _Ready()
    {
        jumping = false;
        jumpCounter = 1;
    }

    public void handleLoose()
    {
        Sprite looseText = (Sprite)GetNode("lost");
        looseText.Visible = true;
    }

    public void handleWin(int result)
    {
        Texture starTexture = (Texture)ResourceLoader.Load("res://Textures/star.png");
        for (int i = 0; i < result; i++)
        {
            Sprite star = (Sprite)GetNode("star"+(i+1));
            star.Visible = true;
        }
        Sprite winText = (Sprite)GetNode("won");
        winText.Visible = true;
    }

    public override void _Process(float delta)
    {}

    private bool isFallen()
    {
        if (this.GetPosition().y > DISPLAY_Y)
            return true;
        return false;
    }
}
