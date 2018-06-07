using Godot;
using System;

public class Game : Container
{
    public override void _Ready()
    {
        MapInfo map=new MapInfo("Maps");
        
        GD.Print(map.AudioPath);
        GD.Print(map.ThemePath);
        GD.Print(map.ChunkAmount);
        GD.Print(map.ChunkHeight);
        for (int i = 0; i < map.Blocks.Count; i++)
            for (int j = 0; j < map.Blocks[i].Count; j++)
                GD.Print(map.Blocks[i][j]);
    }
}
