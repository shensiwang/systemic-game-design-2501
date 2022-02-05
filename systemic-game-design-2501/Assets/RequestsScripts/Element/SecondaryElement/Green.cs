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
            return "Envigorate";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Fishhead Potion";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Woodland Whispers";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Viral of Thoughtspeak";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Familiar Potion";
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
