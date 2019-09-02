using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricLightTrigger : MonoBehaviour
{
    public VolumetricLightController vLightCon;

    void OnTriggerEnter()
    {
        vLightCon.targetScatter = 1.0f;
    }

    void OnTriggerExit()
    {
        vLightCon.targetScatter = 0.0f;
    }
}
