using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedrock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = false;
        enabled = false;
        material = Material.BEDROCK;
        maxHealth = 1.0f;
        GameEventManager.GameStart += GameStart;
    }
}
