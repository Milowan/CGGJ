﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = true;
        enabled = false;
        material = Material.STONE;
        health = 200.0f;
    }
}
