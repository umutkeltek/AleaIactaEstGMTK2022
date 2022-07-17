using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField]private Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    [SerializeField] Animator animator;
    public AudioSource aud;
    

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {   
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 direction = (mousePosition - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            firePoint.eulerAngles = new Vector3(0, 0, angle);
            
            Shoot();
            
        }
    }
    /*void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }*/
    private void Shoot()
    {   animator.SetTrigger("Attack");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetTrigger("NotAttack");
        aud.Play();    
    }
}
