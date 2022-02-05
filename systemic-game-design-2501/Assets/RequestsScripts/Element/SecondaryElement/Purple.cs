using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : ElementInterface
{
    public ElementInterface AddedWithRed()
    {
        return this;
    }
    public ElementInterface AddedWithBlue()
    {
        return this;
    }
    public ElementInterface AddedWithYellow()
    {
        return this;
    }
    public string PotionName(BaseInterface potionBase)
    {
        if (potionBase.getType() == "Amelioration")
        {
            return "Reconsitution Potion";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Eternal Change";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Deadman's Tongue";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Pinch of Eros";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Possession Liquid";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Purple";
    }
}
