using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : FSMState
{
    void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);   //状态转换
    }

    public override void DoBeforeEntering()   //进入该状态时加载
    {
        ctrl.view.ShowMenu();
        ctrl.cameraManager.ZoomOut();
    }

    public override void DoBeforeLeaving()   //离开该状态时执行
    {
        ctrl.view.HideMenu();
    }

    public void OnStartButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        fsm.PerformTransition(Transition.StartButtonClick);
    }

    public void OnRankButtonClick()
    {
        ctrl.view.ShowRankUI(ctrl.model.Score, ctrl.model.HighScore, ctrl.model.NumbersGame);
    }

    public void OnDestroyButtonClick()
    {
        ctrl.model.ClearData();
        OnRankButtonClick();
    }

    public void OnRestartButtonClick()
    {
        ctrl.model.Restart();
        ctrl.gameManager.ClearShape();
        fsm.PerformTransition(Transition.StartButtonClick);
    }
}
