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
            return "Anti-Allergies Potion";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Flask of Beautification";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Glimpse into The Far";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Dementia Potion";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Flask of Calling: Elemental";
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
