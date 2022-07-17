using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    [SerializeField] private float bulletDestroyTime = 1.0f;
    private GameObject boss;
        
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, bulletDestroyTime);
        boss = GameObject.FindWithTag("Enemy");

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {   if (col.transform.GetComponent<PlayerAtt>() != null)
            {
                col.transform.GetComponent<PlayerAtt>().takeDamage(boss.GetComponent<Enemyy>().str);
            }
           
        }
        
    }
}
