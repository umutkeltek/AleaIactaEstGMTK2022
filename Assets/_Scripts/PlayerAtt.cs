using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtt : MonoSingleton<PlayerAtt>
{
    private int hp;
    private int str;
    
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Str
    {
        get { return str; }
        set { str = value; }
    }

    private void Start()
    {
        hp = GameManager.Instance.playerHPValue;
        str = GameManager.Instance.playerAtkValue;
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            
        }
    }
}
