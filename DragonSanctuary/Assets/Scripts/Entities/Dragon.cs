using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class Dragon : MonoBehaviour
{
    public int goldPerMinute;
    public double goldPerSecond;

    public string dragonName;
    public string personality;

    public DragonManager dragManager;
    public Player player;
    public UIManager uIManager;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        dragManager = gameManager.GetComponent<DragonManager>();
        player = gameManager.GetComponent<Player>();
        uIManager = gameManager.GetComponent<UIManager>();

        goldPerMinute = 1;
        goldPerSecond = 0.01f;
        dragonName = "Name here";
        personality = "Personality here";

        SetInfo();

        InvokeRepeating("GenerateGold",1,1);
    }

    private void SetInfo()
    {
        string[] names = dragManager.GetNames();
        string[] personalities = dragManager.GetPersonalities();

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
        goldPerSecond = goldPerMinute / 60.0;

        // Rounds gold per second to 2 decimal places.
        goldPerSecond = Math.Round(goldPerSecond, 2);
    }

    public void GenerateGold()
    {
        player.totalGold += goldPerSecond;
        uIManager.UpdateSessionStats();
    }
}
