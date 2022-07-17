using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] private float bulletDestroyTime = 1.0f;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, bulletDestroyTime);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {   if (col.transform.GetComponent<Enemyy>() != null)
            {
                col.transform.GetComponent<Enemyy>().TakeDamage(PlayerAtt.Instance.Str);
                
            }
           
        }
        Destroy(gameObject);
    }
}
