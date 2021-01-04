using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(GameModeManager gameModeManager)
    {
        gameModeManager.ModeChanged += GameModeManager_ModeChanged;
        ChangeMode(gameModeManager.Mode);
    }

    protected virtual void ExecMoveModeAction()
    {
    }

    protected virtual void ExecBattleModeAction()
    {
    }

    protected virtual void ExecStageCompleteModeAction()
    {
    }

    private void ChangeMode(GameMode mode)
    {
        switch (mode)
        {
            case GameMode.Move:
                ExecMoveModeAction();
                break;

            case GameMode.Battle:
                ExecBattleModeAction();
                break;
            case GameMode.StageComplete:
                ExecStageCompleteModeAction();
                break;
        }
    }

    private void GameModeManager_ModeChanged(object sender, System.EventArgs e)
    {
        var gameModeManager = sender as GameModeManager;
        var mode = gameModeManager?.Mode ?? GameMode.Move;
        ChangeMode(mode);
    }

}
