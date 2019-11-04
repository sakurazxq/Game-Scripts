using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class View : MonoBehaviour
{
    public Ctrl ctrl;
    public RectTransform logoName;
    public RectTransform menuUI;
    public RectTransform gameUI;
    public GameObject restartButton;
    public GameObject gameOverUI;
    public GameObject settingUI;
    public GameObject rankUI;

    public Text score;
    public Text highScore;
    public Text gameOverScore;

    public Text rankScore;
    public Text rankHighScore;
    public Text rankNumbersGame;
    private GameObject mute;


    void Awake()
    {
        ctrl = GameObject.FindGameObjectWithTag("Ctrl").GetComponent<Ctrl>();
        mute = transform.Find("Canvas/SettingUI/AudioButton/Mute").gameObject;
    }
    
    public void ShowMenu()
    {
        logoName.gameObject.SetActive(true);
        logoName.DOMoveY(770.05f, 0.5f);
        menuUI.gameObject.SetActive(true);
        menuUI.DOMoveY(103.3f, 0.5f);
    }

    public void HideMenu()
    {
        logoName.DOMoveY(1050.9f, 0.5f)
            .OnComplete(delegate { logoName.gameObject.SetActive(false); });   //移动完成时执行
        menuUI.DOMoveY(-103.3f, 0.5f)
            .OnComplete(delegate { menuUI.gameObject.SetActive(false); });
    }

    public void UpdateGameUI(int score, int highScore)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
    }

    public void ShowGameUI(int score = 0,int highScore = 0)
    {
        this.score.text = score.ToString();
        this.highScore.text = highScore.ToString();
        gameUI.gameObject.SetActive(true);
        gameUI.DOMoveY(781.66f, 0.5f);
    }

    public void HideGameUI()
    {
        gameUI.DOMoveY(1040.3f, 0.5f)
            .OnComplete(delegate { gameUI.gameObject.SetActive(false); });
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void ShowGameOverUI(int score = 0)
    {
        gameOverUI.SetActive(true);
        gameOverScore.text = score.ToString();
    }
    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }

    public void OnHomeButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //加载当前场景
    }

    public void OnSettingButtonClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(true);
    }

    public void SetMuteActive(bool isActive)
    {
        mute.SetActive(isActive);
    }
    public void OnSettingUIClick()
    {
        ctrl.audioManager.PlayCursor();
        settingUI.SetActive(false);
    }

    //public void OnRankButtonClick()
    //{
    //    ctrl.audioManager.PlayCursor();
    //    rankUI.SetActive(true);
    //}

    public void ShowRankUI(int score,int highScore,int numbersGame)
    {      
        this.rankScore.text = score.ToString();
        this.rankHighScore.text = highScore.ToString();
        this.rankNumbersGame.text = numbersGame.ToString();
        rankUI.SetActive(true);
    }
    public void OnRankUIClick()
    {
        ctrl.audioManager.PlayCursor();
        rankUI.SetActive(false);
    }
}
