using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public string potionName;
    private void Awake()
    {
        potionName = gameObject.name;
    }
}
