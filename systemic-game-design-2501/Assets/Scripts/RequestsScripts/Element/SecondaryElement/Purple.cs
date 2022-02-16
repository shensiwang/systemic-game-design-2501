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
            return "Calm of the Dead";
        }
        else if (potionBase.getType() == "Mutation")
        {
            return "Perceptual Array";
        }
        else if (potionBase.getType() == "Haruspical")
        {
            return "Deadman's Tongue";
        }
        else if (potionBase.getType() == "Emanation")
        {
            return "Gaze of the Outerside";
        }
        else if (potionBase.getType() == "Evocation")
        {
            return "Solomon's Blood";
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
