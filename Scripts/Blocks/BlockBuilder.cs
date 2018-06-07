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
        Block b;

        setIdFromCode(code);
        setSubIdFromCode(code);

        switch (id)
        {
            case 0:
            b = new AirBlock(subId);
                break;
            /*case 1:
            b;
                break;*/
            default:
            b = new AirBlock(subId);
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

