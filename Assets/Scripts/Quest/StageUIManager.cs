using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : BaseUIManager
{
    [SerializeField] Text stageText;

    public void UpdateUI(int currentStage)
    {
        stageText.text = $"ステージ：{currentStage + 1}";
    }

    protected override void ExecMoveModeAction()
    {
        ShowUI(true);
    }

    protected override void ExecBattleModeAction()
    {
        ShowUI(false);
    }

    protected override void ExecStageCompleteModeAction()
    {
        ShowUI(false);
        stageText.gameObject.SetActive(false);
    }

    private void ShowUI(bool isShown)
    {
        var nextButton = transform.Find("NextButton").gameObject;
        nextButton.SetActive(isShown);
        var returnButton = transform.Find("ReturnButton").gameObject;
        returnButton.SetActive(isShown);
    }
}
