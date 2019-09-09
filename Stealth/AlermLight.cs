using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlermLight : MonoBehaviour
{
    public static AlermLight _instance;

    public bool alermOn = false;
    public float animationSpeed = 1;

    private float lowIntensity = 0;
    private float highIntensity = 0.5f;

    private float targetIntensity;
    private Light light;

    // Start is called before the first frame update
    void Awake()
    {
        targetIntensity = highIntensity;
        alermOn = false;
        _instance = this;
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alermOn)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, Time.deltaTime * animationSpeed);
            if(Mathf.Abs(light.intensity - targetIntensity) < 0.05f)
            {
                if(targetIntensity == highIntensity)
                {
                    targetIntensity = lowIntensity;
                }else if(targetIntensity == lowIntensity)
                {
                    targetIntensity = highIntensity;
                }
            }
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 0, Time.deltaTime * animationSpeed);
        }
    }
}
