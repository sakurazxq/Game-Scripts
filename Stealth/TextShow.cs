using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "WASD to Move\nZ to Switch\nShift to Sneak";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
