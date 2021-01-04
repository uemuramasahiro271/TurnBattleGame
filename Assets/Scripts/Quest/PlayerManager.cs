﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int at;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Attack(EnemyManager enemy)
    {
        enemy.Damage(at);
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }
}
