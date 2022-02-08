using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RepManager
{
    public static RepMaster repMaster;

    public static void SetRepMaster(RepMaster repMaster)
    {
        RepManager.repMaster = repMaster;
    }
}
