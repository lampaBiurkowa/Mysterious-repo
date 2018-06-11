class GroundBlock:Block
{
    public GroundBlock(int subId)
    {
        isCollidable = true;
        texturePath = "Textures/ground" + subId + ".png";
    }
}