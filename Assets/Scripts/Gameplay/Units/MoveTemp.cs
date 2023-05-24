using UnityEngine;
using UnityEngine.AI;

public class MoveTemp : MonoBehaviour
{
    [SerializeField] Transform movePos;
    [SerializeField] NavMeshAgent navMeshAgent;
    public bool flagMove = false;
    //public LayerMask layer;
    public void Start()
    {
        flagMove = false;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.destination = movePos.position;
    }
    private void Update()
    {
        if (flagMove)
        {
            navMeshAgent.Stop();
        }
        else
        {
            navMeshAgent.Resume();
        }
        navMeshAgent.updateRotation = false;
        //navMeshAgent.destination = movePos.position;
    }
    //public bool Detect()
    //{
    //    Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 3, layer); // Layer
    //    if (hit.Length > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 3);
    //}
}
