using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 10;
    

    public static int Lives;
    public int startLives = 10;
    private void Start()
    {
        money = startMoney;
        Lives = startLives;
    }

}
