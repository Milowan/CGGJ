using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipComponent : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            player.CollectComponent(this);
            gameObject.SetActive(false);
        }
    }

    public void PlaceComponent(Vector2 position)
    {
        transform.position = position;
    }

}
