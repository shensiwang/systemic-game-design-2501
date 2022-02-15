using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : ElementInterface
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
            return "Verdant Rejuvenation";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Frogification";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Woodland Whispers";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Vial of Thoughtspeak";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Dyrad's Offering";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Green";
    }
}
