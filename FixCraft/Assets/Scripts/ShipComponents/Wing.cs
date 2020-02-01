using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing : ShipComponent
{
    // Start is called before the first frame update
    void Start()
    {
        type = ShipComponentType.WING;
    }
}
