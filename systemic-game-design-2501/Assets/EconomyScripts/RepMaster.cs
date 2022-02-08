using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepMaster : MonoBehaviour
{
    public Text repTxt;

    int id;
    int reputation;

    [SerializeField]
    int customerRepTimeIncreasementUnit = 5;

    private void Awake()
    {
        RepManager.SetRepMaster(this);
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        id = 2;
        reputation = 0;
    }

    public void IncreaseRep(int amount)
    {
        reputation += amount;
    }

    public void DecreaseRep(int amount)
    {
        reputation -= amount;
    }

    public int CustomerRepTimeIncreasement()
    {
        if (reputation >= 10 && reputation < 20) return customerRepTimeIncreasementUnit * 1;
        else if (reputation >= 20 && reputation < 30) return customerRepTimeIncreasementUnit * 2;
        else if (reputation >= 30 && reputation < 40) return customerRepTimeIncreasementUnit * 3;
        else if (reputation > 40) return customerRepTimeIncreasementUnit * 4;
        else return 0;
    }
}
