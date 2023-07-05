using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.AI;

public class AgentMoventMent : MonoBehaviour
{
    // Start is called before the first frame update


    Vector3 target;
    public bool isMoving = false;

    public bool orderMoving = false;

    Unit unit;
    NavMeshAgent agent;
    void Awake()
    {
        target = gameObject.transform.position;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Start()
    {
        unit = gameObject.GetComponent<Unit>();
    }
    // Update is called once per frame
    void Update()
    {
        //SetTargetPosition();
        //SetAgentPosition();

        // Check if the agent has reached the target position
        //isStopped();

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isMoving = false;
            unit.stateAttack = (int)STATE_ATTACK.IDLE;
            orderMoving = false;
        }
        else
        {
            isMoving = true;
            if (unit.stateAttack != 2)
                unit.stateAttack = (int)STATE_ATTACK.MOVE;
        }
    }
    public void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(target.x + " " + target.y + " " + target.z);
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(target);
            float threshold = 0.1f;
            Vector3 FlipDirection = target - transform.position;
            float dotProduct = Vector3.Dot(FlipDirection, transform.right);
            if (dotProduct < -threshold)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (dotProduct > threshold)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            orderMoving = true;
            isMoving = true;
        }
    }

    public void isStopped()
    {
        Debug.Log(agent.isStopped);
    }

    public void SetTargetWhenStaying(GameObject target)
    {
        agent.SetDestination(new Vector2(target.transform.position.x, target.transform.position.y));

        isMoving = true;
    }

    public void StopMoving()
    {
        if (gameObject != null)
        {
            agent.isStopped = true;
            isMoving = false;
        }
    }
    public void ContinueMoving()
    {
        try
        {
            if (gameObject != null)
            {
                agent.isStopped = false;
                isMoving = true;
            }
            //Debug.Log(gameObject);

        }
        catch
        {
            //Debug.Log(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Find enemies");
    }
    public bool CheckIsMoving()
    {
        return isMoving;
    }
    public void SetAgentPosition()
    {
        if (gameObject.GetComponent<Unit>().HitPoints > 0f && gameObject != null)
            agent.ResetPath();
        //agent.SetDestination(transform.position);
        /*agent.ResetPath();
        agent.isStopped = false;*/

    }
    public float GetSpeed()
    {
        return agent.speed;
    }

    public void AdjustSpeed(float speed)
    {
        if (agent != null)
        {
            agent.speed = speed;
        }
    }


}
