using Godot;
using System;
using System.Collections.Generic;

class MapLoader
{
    private List<Block> blocks = new List<Block>();
    private List<Layer> layers = new List<Layer>();
    private List<Chunk> chunks = new List<Chunk>();
    private Map map;

    public Map Map
    {
        get
        {
            return map;
        }
    }

    public MapLoader()
    {
        createBlocks();
        createLayers();
        createChunks();
        createMap();
    }

    private void createBlocks()
    {
        for (int i = 0; i < MapInfo.Blocks.Count; i++)
        {
            for (int j = 0; j < MapInfo.Blocks[i].Count; j++)
            {
                BlockBuilder blockBuilder = new BlockBuilder();
                blocks.Add(blockBuilder.BuildBlock(MapInfo.Blocks[i][j]));
            }
        }
    }

    private void createLayers()
    {
        List<Block> blockSublist = new List<Block>();
        GD.Print(blocks.Count);
        GD.Print(MapInfo.Blocks.Count);
        GD.Print(MapInfo.Blocks[0].Count);
        for (int i = 0; i < blocks.Count; i++)
        {
            if (i != 0 && i % (MapInfo.ChunkHeight * MapInfo.ChunkWidth)  == 0)
            {
                Layer layer;
                layer.XBlockAmount = MapInfo.ChunkWidth;
                layer.YBlockAmount = MapInfo.ChunkHeight;
                layer.Blocks = blockSublist;
                layers.Add(layer);
                blockSublist=new List<Block>();
            }
            blockSublist.Add(blocks[i]);
        }
    }

    private void createChunks()
    {
        int counter=0;
        for (int i = 0; i < MapInfo.Layers.Count; i++)
        {
            List<Layer> layerSublist = new List<Layer>();
            for (int j = 0; j < MapInfo.Layers[i]; j++)
            {
                layerSublist.Add(layers[counter]);
            }
            Chunk chunk;
            chunk.Layers = layerSublist;
            chunks.Add(chunk);
            counter++;
        }
    }

    private void createMap()
    {
        map.ChunkWidth = MapInfo.ChunkWidth;
        map.ChunkHeight = MapInfo.ChunkHeight;
        map.Chunks = chunks;
    }
}

public class Game : Container
{
    public override void _Ready()
    {
        MapInfo map=new MapInfo("Maps");
        MapLoader mapLoader=new MapLoader();
        GD.Print("GOU!");
        GD.Print(mapLoader.Map.Chunks.Count);
        GD.Print(mapLoader.Map.Chunks[0].Layers.Count);
        GD.Print(mapLoader.Map.Chunks[0].Layers[0].Blocks.Count);
        GD.Print(mapLoader.Map.Chunks[0].Layers[0].Blocks.Count);
        GD.Print(mapLoader.Map.Chunks[0].Layers[0].Blocks[0]);
        GD.Print("DASD");
        //tests
        /*GD.Print(MapInfo.AudioPath);
        GD.Print(MapInfo.ThemePath);
        GD.Print(MapInfo.ChunkAmount);
        GD.Print(MapInfo.ChunkHeight);*/
        /*for (int i = 0; i < map.Blocks.Count; i++)
            for (int j = 0; j < map.Blocks[i].Count; j++)
                GD.Print(map.Blocks[i][j]);*/
    }
}
