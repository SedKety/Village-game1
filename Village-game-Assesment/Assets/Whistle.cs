using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Whistle : EnemyScript
{
    public void Start()
    {
        navMeshAgent.destination = FindObjectOfType<PlayerManager>().transform.position;
    }
}
