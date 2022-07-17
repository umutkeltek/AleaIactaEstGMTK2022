using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemyy : MonoBehaviour
{
    public int health;
    public int str ;
    [SerializeField] float fireRate = 1;
    [SerializeField] private Transform[] attackPos;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        health = GameManager.Instance.monsterHPValue;
        str = GameManager.Instance.monsterAtkValue;
        Time.timeScale = 1;

    }

    private void Update()
    {
        
        Vector3 playerPos = new Vector3(player.position.x, player.position.y , player.position.z);
        for (int i = 0; i < attackPos.Length; i++)
        {
            Vector3 aimDirection = (playerPos - attackPos[i].position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            attackPos[i].eulerAngles = new Vector3(0, 0, angle);

        }

        /*for (int i = 0; i < attackPos.Length; i++)
        {   attackPos[i].LookAt(playerPos);
            /*Vector3 direction = (player.position - attackPos[i].position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            attackPos[i].eulerAngles = new Vector3(0,0,angle);#1#
        }*/
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
    {
        var whichAttackPosition = Random.Range(0, attackPos.Length);
        var bulletInstance = Instantiate(bullet, attackPos[whichAttackPosition].position, attackPos[whichAttackPosition].rotation);
        
        /*if (Time.time > fireRate)
        {
            ;;
            fireRate = Time.time + 1 / str;
        }*/

        /*float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPos[whichAttackPosition].eulerAngles = new Vector3(0, 0, angle);*/

    }
}
