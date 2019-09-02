<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
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
>>>>>>> 1d8fe8c08b28c74b2f92cf002b742f23a92ee478
