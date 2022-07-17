using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour
{
    private int health;
    private int str;

    private void Start()
    {
        health = GameManager.Instance.monsterHPValue;
        str = GameManager.Instance.monsterAtkValue;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        
    }
}
