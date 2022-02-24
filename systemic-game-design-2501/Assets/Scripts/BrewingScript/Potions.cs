using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public string potionName;
    public string potionType;
    public string potionElement;
    private void Awake()
    {
        potionName = gameObject.name;
    }
}
