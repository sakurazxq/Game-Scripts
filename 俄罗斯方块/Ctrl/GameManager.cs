using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPause = true;
    private Shape currentShape = null;
    private Ctrl ctrl;

    public Shape[] shapes;
    public Color[] colors;
    public Transform blockHolder;

    void Awake()
    {
        ctrl = GetComponent<Ctrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;
        if(currentShape == null)   //当currentShape落下时调用
        {
            SpawnShape();
        }

    }

    public void ClearShape()
    {
        if (currentShape != null)
        {
            Destroy(currentShape.gameObject);
            currentShape = null;
        }
    }

    public void StartGame()
    {
        isPause = false;
        if (currentShape != null)
            currentShape.Resume();
    }
    public void PauseGame()
    {
        isPause = true;
        if (currentShape != null)
            currentShape.Pause();
    }

    void SpawnShape()
    {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);
        currentShape = GameObject.Instantiate(shapes[index]);   //位置是prefab的默认位置
        currentShape.transform.parent = blockHolder;
        currentShape.Init(colors[indexColor],ctrl,this);
    }

    public void FallDown()  //方块落下来了
    {
        currentShape = null;
        if (ctrl.model.isDataUpdate)
        {
            ctrl.view.UpdateGameUI(ctrl.model.Score, ctrl.model.HighScore);
        }

        foreach(Transform t in blockHolder)
        {
            if (t.childCount <= 1)
            {
                Destroy(t.gameObject);
            }
        }

        if (ctrl.model.IsGameOver())
        {
            PauseGame();
            ctrl.view.ShowGameOverUI(ctrl.model.Score);
        }
    }
}
