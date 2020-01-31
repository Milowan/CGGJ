using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool mineable;


    protected float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

}
