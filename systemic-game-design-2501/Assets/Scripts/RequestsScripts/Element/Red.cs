using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : ElementInterface
{
    public ElementInterface AddedWithRed()
    {
        return new SuperRed();
    }
    public ElementInterface AddedWithBlue()
    {
        return new Purple();
    }
    public ElementInterface AddedWithYellow()
    {
        return new Orange();
    }
    public string PotionName(BaseInterface potionBase)
    {
        if (potionBase.getType() == "Transformation")
        {
            return "Breath of Flare";
        }
        else if (potionBase.getType() == "Mental")
        {
            return "Adrenaline Boost";
        }
        else if (potionBase.getType() == "Body")
        {
            return "Lion's Roar";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Red";
    }
}

