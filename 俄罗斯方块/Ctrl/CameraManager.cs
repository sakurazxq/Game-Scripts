﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    public void ZoomIn()
    {
        mainCamera.DOOrthoSize(14f, 0.5f);
    }

    public void ZoomOut()
    {
        mainCamera.DOOrthoSize(21f, 0.5f);
    }
}
