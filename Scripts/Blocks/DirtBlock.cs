class DirtBlock:Block
{
    public DirtBlock(int subId)
    {
        isCollidable = true;
        texturePath = "Textures/dirt"+subId+".png";
    }
}