using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Diagnostics;

public class AimWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponTransform;
    public event EventHandler<OnShootEventArgs>  OnShoot;
    [SerializeField] private Transform gunEndPoint;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPosition;
        public Vector3 shootPosition;
    }
    

    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0))
        {   Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPosition = gunEndPoint.position,
                shootPosition = mousePosition,
            });
        }
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition(); 
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        weaponTransform.eulerAngles = new Vector3(0,0,angle);
    }
}
