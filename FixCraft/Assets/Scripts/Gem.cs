using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    void Start()
    {
        GameEventManager.GameStart += GameStart;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
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
        //transform.position = Vector2(Random.Range())
    }
}
