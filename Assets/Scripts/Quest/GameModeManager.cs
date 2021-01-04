using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    private GameMode mode;

    public event EventHandler ModeChanged;

    public GameMode Mode => mode;

    // Start is called before the first frame update
    void Start()
    {
        mode = GameMode.Move;
    }

    public void SwitchMode(GameMode mode)
    {
        this.mode = mode;
        OnChanged();
    }

    public void SwitchToMoveMode()
    {
        mode = GameMode.Move;
        OnChanged();
    }

    public void SwitchToBattleMode()
    {
        mode = GameMode.Battle;
        OnChanged();
    }

    private void OnChanged()
    {
        ModeChanged.Invoke(this, EventArgs.Empty);
    }
}
