using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public float speedDampTime = 0.3f;
    public float anglarSpeedDampTime = 0.3f;

    private NavMeshAgent navAgent;
    private Animator anim;
    private EnemySight sight;
    private PlayerHealth health;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sight = GetComponent<EnemySight>();
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(navAgent.desiredVelocity == Vector3.zero)
        {
            anim.SetFloat("Speed", 0,speedDampTime,Time.deltaTime);
            anim.SetFloat("AnglarSpeed", 0,anglarSpeedDampTime,Time.deltaTime);
        }
        else
        {
            float angle = Vector3.Angle(transform.forward, navAgent.desiredVelocity);
            float angleRad = 0;
            if(angle > 90)
            {
                anim.SetFloat("Speed", 0, speedDampTime, Time.deltaTime);
            }
            else
            {//即目标方向在机器人朝向上的投影，求得实时移动速度，达到平滑过渡目的；走向过程中呈弧形，并慢慢加速                
                Vector3 projection = Vector3.Project(navAgent.desiredVelocity, transform.forward);
                anim.SetFloat("Speed", projection.magnitude, speedDampTime, Time.deltaTime);
            }
            angleRad = angle * Mathf.Deg2Rad;//角度转换为弧度

            //控制机器人的左右转向,Cross为以transform.forward和navAgent.desiredVelocity分别为拇指和食指的
            //左手坐标系，返回中指指向的向量
            Vector3 crossRes = Vector3.Cross(transform.forward, navAgent.desiredVelocity);
            if(crossRes.y < 0)//若crossRes.y < 0，则右转
            {
                angleRad = -angleRad;
            }

            anim.SetFloat("AnglarSpeed", angleRad, anglarSpeedDampTime, Time.deltaTime);
            navAgent.nextPosition = transform.position;
        }

        if (health.hp > 0)
        {
            anim.SetBool("PlayerInSight", sight.playerInSight);
        }
        else
        {
            anim.SetBool("PlayerInSight", false);
        }
    }
}
