using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //public Shader myShader;

    public Material graphicMat;

    // Start is called before the first frame update
    void Start()
    {
        //graphicMat = new Material(myShader);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRenderImage(RenderTexture sourceTexture, RenderTexture desTexture)
    {
        Graphics.Blit(sourceTexture, desTexture, graphicMat);
    }
}
