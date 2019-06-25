using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSound : MonoBehaviour
{
    public AudioSource sound;
    public Slider sd;

    public void Con_Sound()
    {
        sound.volume = sd.value;
    }
}
