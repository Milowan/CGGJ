using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = true;
        enabled = false;
        material = Material.DIRT;
        maxHealth = 100.0f;
        health = maxHealth;
        GameEventManager.GameStart += GameStart;
    }
}
