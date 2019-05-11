using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class Dragon : MonoBehaviour
{
    public int goldIncome;
    public string dragonName;

    public string personality;

    public DragonManager dragManager;

    private void Start()
    {
        dragManager = GameObject.Find("GameManager").GetComponent<DragonManager>();

        goldIncome = 1;
        dragonName = "Name here";
        personality = "Personality here";

        string[] names = dragManager.GetNames();
        string[] personalities = dragManager.GetPersonalities();

        SetInfo(names,personalities);
    }

    private void SetInfo(string[] names, string[] personalities)
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

    public void SetPersonality(string[] personalities)
    {
        int ranNum = Random.Range(0, personalities.Length);

        if(personalities[ranNum] == "Angry")
            dragManager.SetPersonalityAngry(this);
        if(personalities[ranNum] == "Calm")
            dragManager.SetPersonalityCalm(this);
    }

    public void SetGoldPS()
    {

    }
}
