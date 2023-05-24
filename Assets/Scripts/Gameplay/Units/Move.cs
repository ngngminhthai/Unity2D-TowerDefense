using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] Transform movePos;
    [SerializeField] NavMeshAgent navMeshAgent;
    public void Start()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }
    private void Update()
    {
        navMeshAgent.destination = movePos.position;
    }
}
