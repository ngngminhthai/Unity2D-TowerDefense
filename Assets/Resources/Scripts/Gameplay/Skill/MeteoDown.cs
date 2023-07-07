using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoDown : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 100f;

    private Vector3 targetPosition;

    [SerializeField]
    private GameObject replacementPrefab;

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
       
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 2.5f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            SpawnReplacementObject();
            Destroy(gameObject);
        }
    }

    private void SpawnReplacementObject()
    {
        Instantiate(replacementPrefab, targetPosition, Quaternion.identity);
    }




    public  void DoesEffectBehaviour()
    {
            //AgentMoventMentMonster agent = targetGameObjectPrefab.GetComponent<AgentMoventMentMonster>();
            //if (agent != null && !agent.isAccessMovingTower)
            //{
            //    float speed = agent.GetSpeed();
            //    //agent.AdjustSpeed((float)0.5);
            //    agent.AdjustSpeed((float)0.5, 3.0f, posionPrefab);
            //    float speedAfter = agent.GetSpeed();
            //}
        //}
    }
}
