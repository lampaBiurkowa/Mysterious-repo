class BridgeBlock:Block
{
    public BridgeBlock(int subId)
    {
        isCollidable = true;
        texturePath = "Textures/bridge" + subId + ".png";
    }
}