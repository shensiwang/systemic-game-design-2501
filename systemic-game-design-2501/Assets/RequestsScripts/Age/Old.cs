using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old : AgeInterface
{
    public float getTimeLimit()
    {
        return 10f;
    }

    public string getAge()
    {
        return "Old";
    }
}

