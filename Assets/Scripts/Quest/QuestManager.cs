using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    [SerializeField] StageUIManager stageUI;
    [SerializeField] PlayerUIManager playerUI;
    [SerializeField] EnemyUIManager enemyUI;
    [SerializeField] StageCompleteUIManager stageCompleteUI;
    [SerializeField] GameModeManager gameModeManager;
    [SerializeField] BattleManager battleManager;
    [SerializeField] GameObject questBG;

    //[SerializeField] GameObject enemyPrefab1;
    //[SerializeField] GameObject enemyPrefab2;

    private int currentStage = 0;
    private int maxStageCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        stageUI.UpdateUI(currentStage);

        stageUI.Setup(gameModeManager);
        //playerUI.Setup(gameModeManager);
        enemyUI.Setup(gameModeManager);
        stageCompleteUI.Setup(gameModeManager);

        battleManager.AddEventListenerOnEndBattle(EndBattle);
    }

    public void OnNextButtonClick()
    {
        SountdManager.instance.PlaySE(0);

        stageUI.HideButton();

        StartCoroutine(Searching());
    }

    public void OnReturnButtonClick()
    {
        SountdManager.instance.PlaySE(0);

        currentStage = 0;

        stageUI.UpdateUI(currentStage);
    }

    public void EndBattle()
    {
        gameModeManager.SwitchMode(GameMode.Move);
    }

    private IEnumerator Searching()
    {
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f)
            .OnComplete(() => questBG.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f));

        var questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(2f);

        currentStage++;

        if (maxStageCount <= currentStage)
        {
            QuestClear();
        }
        else
        {
            stageUI.UpdateUI(currentStage);

            int num = CreateRandomNum();
            EncountEnemy(num);
        }
    }

    private int CreateRandomNum()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        return Random.Range(0, 5);
    }

    private void EncountEnemy(int num)
    {
        GameObject enemyObj = GetEnemy(num);

        if(enemyObj != null)
        {
            gameModeManager.SwitchMode(GameMode.Battle);
            var enemy = enemyObj.GetComponent<EnemyManager>();
            battleManager.Setup(enemy);
        }
        else
        {
            stageUI.ShowButton();
        }
    }

    private GameObject GetEnemy(int num)
    {
        switch(num)
        {
            case (int)EnemyType.enemyA:
                return Instantiate((GameObject)Resources.Load("Prefabs/Enemy/EnemyPrefab1"));

            case (int)EnemyType.enemyB:
                return Instantiate((GameObject)Resources.Load("Prefabs/Enemy/EnemyPrefab2"));

            default:
                return null;
        }
    }

    private void QuestClear()
    {
        SountdManager.instance.StopBGM();
        SountdManager.instance.PlaySE(3);

        gameModeManager.SwitchMode(GameMode.StageComplete);
    }

}
