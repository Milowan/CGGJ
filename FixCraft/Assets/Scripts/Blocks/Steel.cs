using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = true;
        enabled = false;
        material = Material.STEEL;
        maxHealth = 1000.0f;
        health = maxHealth;
        GameEventManager.GameStart += GameStart;
    }
}
