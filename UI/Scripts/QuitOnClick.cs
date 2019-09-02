<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
>>>>>>> 1d8fe8c08b28c74b2f92cf002b742f23a92ee478
}