using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public double totalGold;
    public int totalDragons;

    public UIManager uIManager;


    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("GameManager").GetComponent<UIManager>();

        totalGold = 1000;

        uIManager.UpdateSessionStats();
    }
}
