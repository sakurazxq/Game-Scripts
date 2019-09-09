using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;

    public float hp = 100f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            anim.SetBool("Dead", false);
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }
}
