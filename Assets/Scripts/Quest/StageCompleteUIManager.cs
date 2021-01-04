using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCompleteUIManager : BaseUIManager
{
    [SerializeField] Text completeText;

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
        completeText.gameObject.SetActive(isShown);
    }
}
