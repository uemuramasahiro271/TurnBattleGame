using UnityEngine;
using UnityEngine.UI;

public class StageUIManager : BaseUIManager
{
    [SerializeField] Text stageText;

    public void UpdateUI(int currentStage)
    {
        stageText.text = $"ステージ：{currentStage + 1}";
    }

    public void ShowButton()
    {
        ShowNextButton(true);
        ShowReturnButton(true);
    }

    public void HideButton()
    {
        ShowNextButton(false);
        ShowReturnButton(false);
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
        ShowNextButton(false);
        ShowReturnButton(true);
    }

    private void ShowUI(bool isShown)
    {
        ShowNextButton(isShown);
        ShowReturnButton(isShown);
    }

    private void ShowNextButton(bool isShown)
    {
        var nextButton = transform.Find("NextButton").gameObject;
        nextButton.SetActive(isShown);
    }

    private void ShowReturnButton(bool isShown)
    {
        var returnButton = transform.Find("ReturnButton").gameObject;
        returnButton.SetActive(isShown);
    }
}
