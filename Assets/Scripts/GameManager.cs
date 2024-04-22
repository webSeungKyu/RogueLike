using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool penetrate = false; //ฐüล๋ทย
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    public void HitEnemy(Enemy enemy, float damage)
    {
        enemy.hp -= damage;
        if(enemy.hp <= 0)
        {
            enemy.Die();
        }

    }
}
