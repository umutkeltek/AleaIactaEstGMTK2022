using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : MonoSingleton<RollDice>
{
    public GameObject dice;
    private int totalDiceValue;
    

    
    public int[] RollDiceList (int diceCount)
    {
        int[] dice = new int[diceCount];
        for (int i = 0; i < diceCount; i++)
        {
            dice[i] = Random.Range(1, 7);
        }
        return dice;
    }

    private void CalculateTotalDiceValue(int[] dice)
    {
        int total = 0;
        for (int i = 0; i < dice.Length; i++)
        {
            totalDiceValue += dice[i];
        }
    }

    private void SetHpPlayer(int hp)
    {
        PlayerAtt.Instance.Hp = hp;
    }

}
