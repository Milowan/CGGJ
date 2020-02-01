using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = true;
        gameObject.SetActive(false);
        material = Material.DIRT;
        health = 100.0f;
    }
}
