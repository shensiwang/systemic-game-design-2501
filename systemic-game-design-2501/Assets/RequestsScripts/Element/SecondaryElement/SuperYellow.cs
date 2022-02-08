using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperYellow : ElementInterface
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
            return "Touch of Wonderment";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Narcissus Blend";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Fortuitous Visions";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Pinch of Eros";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Toadstool Essence";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Super Yellow";
    }
}
