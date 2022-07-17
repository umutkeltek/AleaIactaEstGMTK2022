using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    private Transform firePoint;
    public GameObject bulletPrefab;
   

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 direction = (mousePosition - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
