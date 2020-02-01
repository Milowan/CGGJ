using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    private Cone cone;
    private Engine engine;
    private Fuel fuel;
    private Wing wing;

    private Vector2 conePosition;
    private Vector2 enginePosition;
    private Vector2 fuelPosition;
    private Vector2 wingPosition;

    // Start is called before the first frame update
    void Start()
    {
        cone = null;
        engine = null;
        fuel = null;
        wing = null;
    }

    public void AttachComponent(ShipComponent component)
    {
        if (component.GetShipComponentType() == ShipComponentType.CONE)
        {
            cone = (Cone)component;
            component.PlaceComponent(conePosition);
        }
        else if (component.GetShipComponentType() == ShipComponentType.ENGINE)
        {
            engine = (Engine)component;
            component.PlaceComponent(enginePosition);
        }
        else if (component.GetShipComponentType() == ShipComponentType.FUEL)
        {
            fuel = (Fuel)component;
            component.PlaceComponent(fuelPosition);
        }
        else if (component.GetShipComponentType() == ShipComponentType.WING)
        {
            wing = (Wing)component;
            component.PlaceComponent(wingPosition);
        }
    }
}
