using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager lm;
    public GameObject plane;
    private Vector3 pos = Vector3.zero;
    public Vector3 origin = new Vector3(0, -1.41f, 0);
    
    void Awake()
    {
        lm = this;
    }

    void Start()
    {
        MakePlane();
    }

    public void MakePlane()
    {
        origin = origin + Vector3.forward * Random.Range(7f,15f);
        Instantiate(plane, origin, plane.transform.rotation);
    }
}
