using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtt : MonoSingleton<PlayerAtt>
{
    private int hp = 0;
    [SerializeField] private int str;
    
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

}
