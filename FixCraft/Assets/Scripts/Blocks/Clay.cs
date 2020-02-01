using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clay : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = true;
        enabled = false;
        material = Material.CLAY;
        health = 150.0f;
    }
}
