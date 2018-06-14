using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class BlockBuilder
{
    int id;
    int subId;

    public Block BuildBlock(string code)
    {
        Block b = new Block();

        setIdFromCode(code);
        setSubIdFromCode(code);

        switch (id)
        {
            case 0:
            AirBlock airBlock = new AirBlock(subId);
            b.TexturePath = airBlock.TexturePath;
            b.IsCollidable = airBlock.IsCollidable;
                break;
            case 1:
            GroundBlock groundBlock = new GroundBlock(subId);
            b.TexturePath = groundBlock.TexturePath;
            b.IsCollidable = groundBlock.IsCollidable;
                break;
            case 2:
            GrassBlock grassBlock = new GrassBlock(subId);
            b.TexturePath = grassBlock.TexturePath;
            b.IsCollidable = grassBlock.IsCollidable;
                break;
            case 3:
            BridgeBlock bridgeBlock = new BridgeBlock(subId);
            b.TexturePath = bridgeBlock.TexturePath;
            b.IsCollidable = bridgeBlock.IsCollidable;
                break;
            case 4:
            DirtBlock dirtBlock = new DirtBlock(subId);
            b.TexturePath = dirtBlock.TexturePath;
            b.IsCollidable = dirtBlock.IsCollidable;
                break;
            default:
            AirBlock derivedBlock = new AirBlock(subId);
            b.TexturePath = derivedBlock.TexturePath;
            b.IsCollidable = derivedBlock.IsCollidable;
                break;
        }
        return b;
    }

    private void setIdFromCode(string code)
    {
        int id = Int32.Parse(code.Split(':')[0]);
        this.id = id;
    }

    private void setSubIdFromCode(string code)
    {
        int subId = Int32.Parse(code.Split(':')[1]);
        this.subId = subId;
    }
}

