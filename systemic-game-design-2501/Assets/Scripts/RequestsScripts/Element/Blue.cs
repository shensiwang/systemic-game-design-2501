using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : ElementInterface
{
    public ElementInterface AddedWithRed()
    {
        return new Purple();
    }
    public ElementInterface AddedWithBlue()
    {
        return new SuperBlue();
    }
    public ElementInterface AddedWithYellow()
    {
        return new Green();
    }
    public string PotionName(BaseInterface potionBase)
    {
        if (potionBase.getType() == "Transformation")
        {
            return "Diver Down";
        }
        else if (potionBase.getType() == "Mental")
        {
            return "Moody Blues";
        }
        else if (potionBase.getType() == "Body")
        {
            return "Bone Joint Grease";
        }
        else
        {
            return null;
        }

    }
    public string getName()
    {
        return "Blue";
    }
}

