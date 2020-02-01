using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedrock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        mineable = false;
        gameObject.SetActive(false);
        material = Material.BEDROCK;
        health = 1.0f;
    }
}
