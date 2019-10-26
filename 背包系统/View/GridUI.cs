using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
#region Enter&&Exit
    public static Action<Transform> OnEnter;
    public static Action OnExit;

    

    public void OnPointerEnter(PointerEventData eventData)  //鼠标移过去时触发
    {
        if(eventData.pointerEnter.tag == "Grid")   //射线检测鼠标下面的物体是否tag为Grid
        {
            if (OnEnter!=null)
                OnEnter(transform);   //参数为该处格子的位置
        }
    }

    public void OnPointerExit(PointerEventData eventData)    //鼠标离开时触发
    {
        if (eventData.pointerEnter.tag == "Grid")
        {
            if (OnExit != null)
                OnExit();
        }
    }
    #endregion

    public static Action<Transform> OnLeftBeginDrag;
    public static Action<Transform,Transform> OnLeftEndDrag;   //参数是拖动之前的位置和拖动之后的位置

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)  //按下鼠标左键时
        {
            if (OnLeftBeginDrag != null)
                OnLeftBeginDrag(transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)   //松开鼠标左键时
        {
            if (OnLeftEndDrag != null)
            {
                if(eventData.pointerEnter == null)   //如果鼠标下面没有UI
                    OnLeftEndDrag(transform,null);
                else
                    OnLeftEndDrag(transform, eventData.pointerEnter.transform);
            }
        }
    }
}
