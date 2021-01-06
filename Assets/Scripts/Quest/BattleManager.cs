using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Transform playerDamageObj;
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
        SountdManager.instance.PlayBGM("Battle");

        playerUI.SetupUI(player);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    private void PlayerAttack()
    {
        StopAllCoroutines();

        SountdManager.instance.PlaySE(1);

        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);

        if(enemy.hp == 0)
        {
            StartCoroutine(EndBattle());
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        SountdManager.instance.PlaySE(1);

        playerDamageObj.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    private IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);

        Destroy(enemy.gameObject);
        SountdManager.instance.PlayBGM("Quest");
        endBattleAction();
    }

}
