using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Testing1 : MonoBehaviour
{
    [SerializeField] private AimWeapon aimWeapon;

    private void Start()
    {
        aimWeapon.OnShoot += AimWeapon_OnShoot;
    }
    private void AimWeapon_OnShoot(object sender, AimWeapon.OnShootEventArgs e)
    {
        UtilsClass.ShakeCamera(0.01f,0.15f);
        WeaponTracer.Create(e.gunEndPosition, e.shootPosition);
        Shoot_Flash.AddFlash(e.shootPosition);
        
    }
}
