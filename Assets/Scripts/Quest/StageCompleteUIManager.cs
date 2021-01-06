using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCompleteUIManager : BaseUIManager
{
    protected override void ExecMoveModeAction()
    {
        ShowUI(false);
    }

    protected override void ExecBattleModeAction()
    {
        ShowUI(false);
    }

    protected override void ExecStageCompleteModeAction()
    {
        ShowUI(true);
    }

    private void ShowUI(bool isShown)
    {
        gameObject.SetActive(isShown);
    }
}
