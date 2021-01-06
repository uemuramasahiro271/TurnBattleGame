using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : BaseUIManager
{
    [SerializeField] Text nameText;
    [SerializeField] Text hpText;

    public void SetupUI(EnemyManager enemy)
    {
        nameText.text = enemy.name;
        hpText.text = $"HP：{enemy.hp}";
    }

    public void UpdateUI(EnemyManager enemy)
    {
        hpText.text = $"HP：{enemy.hp}";
    }
    protected override void ExecMoveModeAction()
    {
        ShowUI(false);
    }

    protected override void ExecBattleModeAction()
    {
        ShowUI(true);
    }

    protected override void ExecStageCompleteModeAction()
    {
        ShowUI(false);
    }

    private void ShowUI(bool isShown)
    {
        //nameText.gameObject.SetActive(isShown);
        //hpText.gameObject.SetActive(isShown);

        gameObject.SetActive(isShown);
    }
}
