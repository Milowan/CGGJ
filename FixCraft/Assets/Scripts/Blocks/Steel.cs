using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = true;
        gameObject.SetActive(false);
        material = Material.STEEL;
        health = 250.0f;
    }
}
