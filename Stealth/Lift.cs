using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lift : MonoBehaviour
{
    public Transform outerLeft;
    public Transform innerLeft;
    public Transform outerRight;
    public Transform innerRight;
    public float liftUpTime = 3f;
    private float liftUpTimer = 0;
    private bool isIn = false;
    private float gameWinTimer = 0;

    // Update is called once per frame
    void Update()
    {
        innerLeft.position = new Vector3(outerLeft.position.x, innerLeft.position.y, innerLeft.position.z);
        innerRight.position = new Vector3(outerRight.position.x, innerRight.position.y, innerRight.position.z);

        if (isIn)
        {
            liftUpTimer += Time.deltaTime;
            if(liftUpTimer > liftUpTime)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
                gameWinTimer += Time.deltaTime;
                if(gameWinTimer > 1f)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.player)
        {
            isIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.player)
        {
            isIn = false;
            liftUpTimer = 0;
        }
    }
}
