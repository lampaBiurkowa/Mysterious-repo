class GrassBlock:Block
{
    public GrassBlock(int subId)
    {
        isCollidable = true;
        texturePath = "Textures/grass" + subId + ".png";
    }
}