using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour {

    public static Transform Instance = null;                         

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // Dont destroy on reloading the scene
        DontDestroyOnLoad(gameObject);

 
    }

    public PlayerController Player;
    
}
