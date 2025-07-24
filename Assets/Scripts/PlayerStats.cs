using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLines = 20;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLines;
        Rounds = 0;
    }
}
