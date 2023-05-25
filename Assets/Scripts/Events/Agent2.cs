using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent2 : MonoBehaviour
{
    // Start is called before the first frame update


    Vector3 target;

    NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();

    }
    void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(target.x + " " + target.y + " " + target.z);
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(target);
        }

    }
    void SetAgentPosition()
    {

    }
}