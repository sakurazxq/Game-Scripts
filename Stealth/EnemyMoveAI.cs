using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveAI : MonoBehaviour
{
    public Transform[] wayPoints;

    public float patrolTime = 3f;
    public float chaseTime = 3f;
    private float patrolTimer = 0;
    private float chaseTimer = 0;

    private int index = 0;

    private NavMeshAgent navAgent;
    private EnemySight sight;
    private PlayerHealth health;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = wayPoints[index].position;//导航的目标位置
        navAgent.updatePosition = false;
        navAgent.updateRotation = false;
        sight = GetComponent<EnemySight>();
        health = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sight.playerInSight && health.hp > 0)
        {
            Shooting();
        }
        else if (sight.alertPosition != Vector3.zero && health.hp > 0)
        {
            Chasing();
        }
        else
        {
            Patrolling();
        }      
    }

    private void Shooting()
    {
        //navAgent.Stop();
        navAgent.isStopped = true;
    }

    //巡逻
    private void Patrolling()
    {
        navAgent.isStopped = false;
        navAgent.speed = 3;
        navAgent.destination = wayPoints[index].position;
        navAgent.updatePosition = false;
        navAgent.updateRotation = false;
        if (navAgent.remainingDistance < 0.01f)
        {
            patrolTimer += Time.deltaTime;
            if (patrolTimer > patrolTime)
            {
                index++;
                index %= 4;
                navAgent.destination = wayPoints[index].position;
                navAgent.updatePosition = false;
                navAgent.updateRotation = false;
                patrolTimer = 0;
            }
        }
    }

    private void Chasing()
    {
        navAgent.isStopped = false;
        navAgent.speed = 6;
        navAgent.destination = sight.alertPosition;
        navAgent.updatePosition = false;
        navAgent.updateRotation = false;
        

        if(navAgent.remainingDistance < 2f)
        {
            chaseTimer += Time.deltaTime;
            if(chaseTimer > chaseTime)
            {
                sight.alertPosition = Vector3.zero;
                GameController._instance.lastPlayerPosition = Vector3.zero;
                GameController._instance.alermOn = false;
            }

        }
    }
}
