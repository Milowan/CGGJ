using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    protected bool mineable;
    private bool mined;
    [SerializeField]
    protected float health;
    protected Material material;

    public void TakeDamage(float damage)
    {
        if (mineable)
        {
            health -= damage;
            if (health <= 0.0f)
                Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        mined = true;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnBecameVisible()
    {
        if (!mined)
            gameObject.SetActive(true);
    }

    protected void GameStart()
    {
        mined = false;
    }

}
