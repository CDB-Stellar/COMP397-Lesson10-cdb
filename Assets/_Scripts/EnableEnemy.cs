using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnableEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float delay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableNavMeshAgent());
    }

    // coroutine to wait before spawning the enemy
    IEnumerator EnableNavMeshAgent()
    {
        yield return new WaitForSeconds(delay);
        agent.enabled = true;
        StopCoroutine(EnableNavMeshAgent());
    }
}
