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

    // Update is called once per frame
    void Update()
    {
        
    }
}
