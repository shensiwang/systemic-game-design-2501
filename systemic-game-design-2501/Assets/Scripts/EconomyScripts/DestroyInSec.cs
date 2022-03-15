using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSec : MonoBehaviour
{
    public float secondToDestroy = 2f;

    void Start()
    {
        Destroy(this.gameObject, secondToDestroy);
    }
}
