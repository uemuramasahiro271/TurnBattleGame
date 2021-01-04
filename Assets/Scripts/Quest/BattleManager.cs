using System;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] PlayerUIManager playerUI;
    [SerializeField] EnemyUIManager enemyUI;
    [SerializeField] PlayerManager player;

    private EnemyManager enemy;

    private Action endBattleAction;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddEventListenerOnEndBattle(Action action)
    {
        endBattleAction += action;
    }

    public void Setup(EnemyManager enemyManager)
    {
        playerUI.SetupUI(player);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    private void PlayerAttack()
    {
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);

        if(enemy.hp == 0)
        {
            Destroy(enemy.gameObject);
            EndBattle();
        }
        else
        {
            EnemyTurn();
        }
    }

    private void EnemyTurn()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    private void EndBattle()
    {
        Debug.Log("バトル終了");
        endBattleAction();
    }

}
