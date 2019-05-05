using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int goldPerSecond;
    public string dragonName;

    public string personality;

    private void Start()
    {
        goldPerSecond = 1;
        dragonName = "Name here";
        personality = "Personality here";
    }
}
