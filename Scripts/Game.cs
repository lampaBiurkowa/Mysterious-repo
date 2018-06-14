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
            for (int j = 0; j < MapInfo.Blocks[i].Count; j++)
            {
                BlockBuilder blockBuilder = new BlockBuilder();
                blocks.Add(blockBuilder.BuildBlock(MapInfo.Blocks[i][j]));
            }
    }

    private void createLayers()
    {
        List<Block> blockSublist = new List<Block>();
        for (int i = 0; i < blocks.Count; i++)
        {
            if (i != 0 && i % (MapInfo.ChunkHeight * MapInfo.ChunkWidth)  == 0)
            {
                Layer layer;
                layer.XBlockAmount = MapInfo.ChunkWidth;
                layer.YBlockAmount = MapInfo.ChunkHeight;
                layer.Blocks = blockSublist;
                layers.Add(layer);
                blockSublist = new List<Block>();
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
                layerSublist.Add(layers[counter]);
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

class MapPositioner
{
    private const int BLOCK_WIDTH = 64;
    private const int BLOCK_HEIGHT = 64;
    private Map map;

    public Map Map
    {
        get
        {
            return map;
        }
    }

    public MapPositioner()
    {
        MapLoader mapLoader = new MapLoader();
        map = mapLoader.Map;
        locateMap();
    }

    private void locateMap()
    {
        for (int i = 0; i < map.Chunks.Count; i++)
            map.Chunks[i] = locateChunk(map.Chunks[i], i);
    }

    private Chunk locateChunk(Chunk chunk, int nr)
    {
        for (int i = 0; i < chunk.Layers.Count; i++)
            chunk.Layers[i] = locateLayer(chunk.Layers[i], nr);
        return chunk;
    }

    private Layer locateLayer(Layer layer, int nr)
    {
        float xPos = 0;
        float yPos = 0;
        for (int i = 0; i < layer.Blocks.Count; i++)
        {
            layer.Blocks[i] = locateBlock(layer.Blocks[i], new Vector2(xPos, yPos));
            layer.Blocks[i].Position = new Vector2(layer.Blocks[i].Position.x + nr * layer.XBlockAmount * BLOCK_WIDTH, layer.Blocks[i].Position.y);
            xPos++;
            if (xPos % layer.XBlockAmount == 0)
            {
                xPos = 0;
                yPos++;
            }
        }
        return layer;
    }

    private Block locateBlock(Block block, Vector2 coors)
    {
        block.Position = new Vector2(coors.x * BLOCK_WIDTH, coors.y * BLOCK_HEIGHT);
        return block;
    }
}

public class Game : Container
{
    private Player player;

    public override void _Ready()
    {
        MapInfo map = new MapInfo("Maps");
        renderMap(new MapPositioner());
        spwanPlayer();
    }

    public override void _Process(float delta)
    {
        player.Move();
    }

    private void renderMap(MapPositioner positioner)
    {
        for (int i = 0; i < positioner.Map.Chunks.Count; i++)
            renderChunks(positioner.Map.Chunks[i]);
    }

    private void renderChunks(Chunk chunk)
    {
        for (int i = 0; i < chunk.Layers.Count; i++)
            renderLayers(chunk.Layers[i]);
    }

    private void renderLayers(Layer layer)
    {
        for (int i = 0; i < layer.Blocks.Count; i++)
            renderBlock(layer.Blocks[i]);
    }

    private void renderBlock(Block block)
    {
        Block instancedBlock = instanceBlock();
        instancedBlock.Position =  block.Position;
        instancedBlock.IsCollidable = block.IsCollidable;
        instancedBlock.handleCollidable();
        Texture texture = (Texture)ResourceLoader.Load(block.TexturePath);
        Sprite instancedSprite = (Sprite)instancedBlock.GetNode("Sprite");
        instancedSprite.Texture = texture;
    }

    private Block instanceBlock()
    {
        PackedScene scene = (PackedScene)ResourceLoader.Load("Scenes/Block.tscn");
        Block instancedBlock = (Block)scene.Instance();
        AddChild(instancedBlock);
        return instancedBlock;
    }

    private void spwanPlayer()
    {
        PackedScene scene = (PackedScene)ResourceLoader.Load("Scenes/Player.tscn");
        player = (Player)scene.Instance();
        AddChild(player);
        player.SetPosition(new Vector2(30f,200f));
    }
}
