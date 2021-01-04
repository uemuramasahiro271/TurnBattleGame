using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : BaseUIManager
{
    [SerializeField] Text hpText;
    [SerializeField] Text atText;

    public void SetupUI(PlayerManager player)
    {
        hpText.text = $"HP：{player.hp}";
        atText.text = $"AT：{player.at}";
    }

    public void UpdateUI(PlayerManager player)
    {
        hpText.text = $"HP：{player.hp}";
        atText.text = $"AT：{player.at}";
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
        hpText.gameObject.SetActive(isShown);
        atText.gameObject.SetActive(isShown);
    }
}
