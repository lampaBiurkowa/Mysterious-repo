using Godot;
using System;

public class Star : TextureButton
{
    public override void _Ready()
    {}

    public override void _Process(float delta)
    {
        if (this.IsPressed())
            this.Visible = false;
    }
}
