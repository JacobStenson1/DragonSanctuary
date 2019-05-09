using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DragonManager : MonoBehaviour
{
    string[] Names;

    // Reads all the names in the DragonNames file and assigns them to a 'Names' array.
    public string[] GetNames()
    {
        string path = "Assets/Text/DragonNames.txt";
        Names = File.ReadAllLines(path);

        return Names;
    }

    public FileInfo[] GetPersonalities()
    {
        string dir = "Assets/Scripts/Entities/Dragon/Personalities/";


        // Make a reference to a directory.
        DirectoryInfo di = new DirectoryInfo(dir);
        // Get a reference to each file in that directory.
        FileInfo[] fiArr = di.GetFiles();
        // Display the names and sizes of the files.
        Debug.Log("Total personalities: " + fiArr.Length);

        return fiArr;
    }
}
