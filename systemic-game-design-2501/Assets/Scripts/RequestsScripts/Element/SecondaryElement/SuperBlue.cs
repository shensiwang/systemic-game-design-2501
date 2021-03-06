using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBlue : ElementInterface
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
            return "Wizard's Brew";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Aqeous Forme";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Potion of Premonition";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Knowledge Mead";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Rusalka's Call";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Super Blue";
    }
}
