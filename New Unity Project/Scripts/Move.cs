using UnityEngine;
using System.Collections;
public class Move : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
