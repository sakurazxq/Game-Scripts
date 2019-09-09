using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float minDamage = 30;

    private Animator anim;
    private bool haveShoot = false;   //表示一次射击中是否计算过伤害
    private PlayerHealth health;

    void Awake()
    {
        anim = GetComponent<Animator>();
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetFloat("Shot") > 0.5)
        {
            Shooting();
        }
        else
        {
            haveShoot = false;
        }
    }

    private void Shooting()
    {
        if(haveShoot == false)
        {
            //计算伤害
            float damage = minDamage + 90 - 9 * (transform.position - health.transform.position).magnitude;
            health.TakeDamage(damage);
            haveShoot = true;
        }
    }
}
