using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRed : ElementInterface
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
            return "War Surge";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Dragonic Shell";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Divine Scryer";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Herculean Serum";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Salamander's Bait";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Super Red";
    }
}
