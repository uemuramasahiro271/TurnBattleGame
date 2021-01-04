using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public string name;
    public int hp;
    public int at;

    Action tapAction;

    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        Debug.Log("クリック");
        tapAction();
    }

    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
    }
}
