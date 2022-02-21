using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Young : AgeInterface
{
    public float getTimeLimit()
    {
        return 10f;
    }

    public string getAge()
    {
        return "Young";
    }
}
