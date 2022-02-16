using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : ElementInterface
{
    public ElementInterface AddedWithRed()
    {
        return new Orange();
    }
    public ElementInterface AddedWithBlue()
    {
        return new Green();
    }
    public ElementInterface AddedWithYellow()
    {
        return new SuperYellow();
    }
    public string PotionName(BaseInterface potionBase)
    {
        if(potionBase.getType() == "Transformation")
        {
            return "Golden Beauty";
        }
        else if(potionBase.getType() == "Mental")
        {
            return "Internal Sunshine!";
        }
        else if(potionBase.getType() == "Body")
        {
           return "King's Complextion";
        }
        else
        {
            return null;
        }
        
    }
    public string getName()
    {
        return "Yellow";
    }
}
