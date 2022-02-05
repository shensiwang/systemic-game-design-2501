using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : ElementInterface
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
            return "Potion of Mechanical Restoration";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Potion of Short Alteration ";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Thousand Miles";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Lightfoot Potion";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Viral of Golem Essence";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Orange";
    }
}
