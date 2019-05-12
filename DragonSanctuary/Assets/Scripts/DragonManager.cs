using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DragonManager : MonoBehaviour
{
    string[] Names;

    public string DragonNamesFile = "DragonNames";
    string txtContents;

    public string[] personalities;

    public int goldPerSecond;
    public string personality;


    // Reads all the names in the DragonNames file and assigns them to a 'Names' array.
    public string[] GetNames()
    {
        TextAsset textAssets = (TextAsset)Resources.Load(DragonNamesFile);
        txtContents = textAssets.text;

        string[] Names = txtContents.Split('\n');

        return Names;
    }

    public string[] GetPersonalities()
    {
        personalities = new string[] { "Angry","Calm" };
        return personalities;
    }

    public void SetPersonalityAngry(Dragon dragon)
    {
        dragon.goldPerMinute = 20;
        dragon.personality = "Angry";
    }

    public void SetPersonalityCalm(Dragon dragon)
    {
        dragon.goldPerMinute = 10;
        dragon.personality = "Calm";
    }

}
