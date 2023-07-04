using System.Collections;
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
        public float originalSpeed;
        Timer timer;
        public bool isSlowed;



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
            timer = gameObject.AddComponent<Timer>();

            originalSpeed = agent.speed;  // Store original speed

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

        public GameObject AdjustSpeed(float speed, float duration, GameObject effectPrefab)
        {
            if (agent != null && !isSlowed)
            {
                agent.speed = speed;
                isSlowed = true;
                GameObject poison = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                poison.transform.parent = transform;
                StartCoroutine(ResetSpeedAfterTime(duration, poison));
                return poison;
            }
            return null;
        }
        public void AdjustSpeed(float speed, float duration)
        {
            if (agent != null && !isSlowed)
            {
                agent.speed = speed;
                isSlowed = true;
            
                StartCoroutine(ResetSpeedAfterTime(duration));
               
            }
         
        }
  

        IEnumerator ResetSpeedAfterTime(float delay, GameObject poison)
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(delay);

            // Reset the speed of the monster to original
            ResetSpeed();
            isSlowed = false;

            // Destroy the poison GameObject
            Destroy(poison);
        }


        IEnumerator ResetSpeedAfterTime(float delay)
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(delay);

            // Reset the speed of the monster to original
            ResetSpeed();
            isSlowed = false;

            // Destroy the poison GameObject
           
        }

        public void ResetSpeed()
        {
            if (agent != null)
            {
                agent.speed = originalSpeed;
            }
        }
    }
}
