class AirBlock:Block
{
    public AirBlock(int subId)
    {
        isCollidable = false;
        texturePath = "Textures/air" + subId + ".png";
    }
}