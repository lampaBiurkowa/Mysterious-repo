class GroundBlock:Block
{
    public GroundBlock(int subId)
    {
        texturePath="Textures/ground"+subId+".png";
        isCollidable = true;
    }
}