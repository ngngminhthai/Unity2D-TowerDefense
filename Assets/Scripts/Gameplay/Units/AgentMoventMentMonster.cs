using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Gameplay.Units
{
    public class AgentMoventMentMonster : MonoBehaviour
    {
        Vector3 target;

        public bool isAccessMovingTower;
        // Chi co 1 tru thi khai bao day luon 
        public GameObject tower;

        NavMeshAgent agent;
        void Awake()
        {
            target = gameObject.transform.position;
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            // init target to tower
            agent.SetDestination(tower.transform.position);
            isAccessMovingTower = false;
        }

        // Update is called once per frame
        void Update()
        {
            // Chua den tru thi cu set target va co duoc Access Moving den Tower hay khong ( dang target defender thi k di chuyen den tower )
            // Truong hop den roi thi khong phai set nua
            if (tower != null)
            {
                if (Vector2.Distance(gameObject.transform.position, tower.transform.position) > 0.1f && isAccessMovingTower == true)
                {
                    agent.SetDestination(tower.transform.position);
                    // Debug.Log("Target tower");
                    isAccessMovingTower = false;
                }
            }
        }
        public void SetTargetPosition(GameObject t)
        {
            Transform transform = t.transform;
            agent.SetDestination(transform.position);
        }
        public void StopMoving()
        {
            if (agent != null)
            {
                agent.isStopped = true;
            }
        }
        public void ContinueMoving()
        {
            if (agent != null)
            {
                agent.isStopped = false;
            }
        }
    }
}
