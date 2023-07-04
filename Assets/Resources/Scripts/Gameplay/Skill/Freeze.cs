using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 3f;
    Timer timer;
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 4;
        timer.Run();
        Invoke("FreezeObjects", 0.0f);

    }

    void FreezeObjects()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        if (colliders.Length > 0) Debug.Log("x");
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("attackers"))
            {
                AgentMoventMentMonster agent = collider.GetComponent<AgentMoventMentMonster>();

                if (agent != null && !agent.isAccessMovingTower)
                {
                    float speed = agent.GetSpeed();
                    //agent.AdjustSpeed((float)0.5);
                    agent.AdjustSpeed((float)0.0, 3f);
                    float speedAfter = agent.GetSpeed();
                    
                }
            }
        }
    }

    void Update()
    {
        //if (timer.Finished)
        //{

        //    Destroy(gameObject);

        //}
    }

}
