using System;
using UnityEngine;
using DG.Tweening;

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
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
        }
    }
}
