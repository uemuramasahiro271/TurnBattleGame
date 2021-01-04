using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] StageUIManager stageUI;
    [SerializeField] PlayerUIManager playerUI;
    [SerializeField] EnemyUIManager enemyUI;
    [SerializeField] StageCompleteUIManager stageCompleteUI;
    [SerializeField] GameModeManager gameModeManager;
    [SerializeField] BattleManager battleManager;

    //[SerializeField] GameObject enemyPrefab1;
    //[SerializeField] GameObject enemyPrefab2;

    private int currentStage = 0;
    private int maxStageCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        stageUI.UpdateUI(currentStage);

        stageUI.Setup(gameModeManager);
        playerUI.Setup(gameModeManager);
        enemyUI.Setup(gameModeManager);
        stageCompleteUI.Setup(gameModeManager);

        battleManager.AddEventListenerOnEndBattle(EndBattle);
    }

    public void OnNextButtonClick()
    {
        currentStage++;

        stageUI.UpdateUI(currentStage);

        if(maxStageCount <= currentStage)
        {
            QuestClear();
            return;
        }

        int num = CreateRandomNum();
        EncountEnemy(num);

    }

    public void OnReturnButtonClick()
    {
        currentStage = 0;

        stageUI.UpdateUI(currentStage);
    }

    public void EndBattle()
    {
        gameModeManager.SwitchMode(GameMode.Move);
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
        //var sceneTransitionManager = Instantiate((SceneTransitionManager)Resources.Load("Prefabs/SceneManager"));
        //sceneTransitionManager.LoadTo("Town");

        gameModeManager.SwitchMode(GameMode.StageComplete);
    }

}
