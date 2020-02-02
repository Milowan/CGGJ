using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    protected bool mineable;
    private bool mined;
    protected float health;
    protected float maxHealth;
    protected Material material;
    public bool GemBlock { get; set; } = false;

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
        if (GemBlock) {
            Instantiate(KugUtil.Instance.GemBaby, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
        mined = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        if (!mined)
            enabled = true;
    }

    protected void GameStart()
    {
        gameObject.SetActive(true);
        mined = false;
        health = maxHealth;
    }

}
