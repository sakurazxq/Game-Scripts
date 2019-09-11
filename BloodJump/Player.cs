using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody myRig;
    private float keyTime = 0;
    public Scrollbar myBar;
    public Text score;
    private float myScore = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            keyTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            myRig.AddForce(new Vector3(0,1,1) * 1000f * keyTime);
            keyTime = 0;
        }

        myBar.size = keyTime;

        if(transform.position.y < -20)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        other.GetComponent<BloodParticle>().StopPtc();
        myScore++;
        score.text = myScore.ToString();
    }
}
