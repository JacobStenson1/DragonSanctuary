using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class Dragon : MonoBehaviour
{
    public int goldPerSecond;
    public string dragonName;

    public string personality;

    public DragonManager dragManager;

    private void Start()
    {
        dragManager = GameObject.Find("GameManager").GetComponent<DragonManager>();

        goldPerSecond = 1;
        dragonName = "Name here";
        personality = "Personality here";

        string[] names = dragManager.GetNames();
        FileInfo[] personalities = dragManager.GetPersonalities();

        SetInfo(names,personalities);
    }

    private void SetInfo(string[] names, FileInfo[] personalities)
    {
        SetName(names);
        SetPersonality(personalities);
        SetGoldPS();
    }

    // ------------------------- //

    // Gives the dragon a name.
    public void SetName(string[] names)
    {
        // Get a name and set the dragonName variable equal to it.
        int ranNum = Random.Range(0, names.Length);
        dragonName = names[ranNum];
    }

    public void SetPersonality(FileInfo[] personalities)
    {
        // What personalities do I want?
        // Angry - more gold but they eat more food?


        // Choose a personality then assign a certain file to this dragon object.

        // -
        // 1. Find a personality to give to a dragon. (How?) Random number?
        // 2. Assign that personality script to the Dragon.

        //personalities;

    }

    public void SetGoldPS()
    {

    }
}
