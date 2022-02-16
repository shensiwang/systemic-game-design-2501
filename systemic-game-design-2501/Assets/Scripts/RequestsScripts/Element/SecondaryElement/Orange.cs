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
            return "Auto-Repair";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Forme of the Marionette ";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Retrace Machination";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Feathered Steps";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Soul Install";
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
