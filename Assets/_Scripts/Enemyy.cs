using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemyy : MonoBehaviour
{
    public int health;
    public int str;
    [SerializeField] float fireRate = 1;
    [SerializeField] private Transform[] attackPos;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        health = GameManager.Instance.monsterHPValue;
        str = GameManager.Instance.monsterAtkValue;
        player = GetComponent<Transform>().transform;

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

    public void BossAttack()
    {   var whichAttackPosition = Random.Range(0, attackPos.Length);
        Debug.Log(whichAttackPosition);
        Vector3 direction = (player.position - attackPos[whichAttackPosition].position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPos[whichAttackPosition].eulerAngles = new Vector3(0, 0, angle);
        Instantiate(bullet, attackPos[whichAttackPosition].position, attackPos[whichAttackPosition].rotation);
    }
}
