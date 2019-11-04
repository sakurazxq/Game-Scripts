using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : FSMState
{
    void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.ShowGameUI(ctrl.model.Score,ctrl.model.HighScore);
        ctrl.cameraManager.ZoomIn();
        ctrl.gameManager.StartGame();
    }

    public override void DoBeforeLeaving()   //离开该状态时执行
    {
        ctrl.view.HideGameUI();
        ctrl.view.ShowRestartButton();
        ctrl.gameManager.PauseGame();
    }

    public void OnPauseButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.PauseButtonClick);
    }

    public void OnRestartButtonClick()
    {
        ctrl.view.HideGameOverUI();
        ctrl.model.Restart();
        ctrl.gameManager.StartGame();
        ctrl.view.UpdateGameUI(0, ctrl.model.HighScore);
    }
}
