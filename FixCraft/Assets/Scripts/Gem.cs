using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.GameStart += GameStart;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;
        if (player = collision.GetComponent<Player>())
        {
            player.SetGems(player.GetGems() + 1);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void GameStart()
    {
        gameObject.SetActive(true);
        enabled = false;
    }
}
