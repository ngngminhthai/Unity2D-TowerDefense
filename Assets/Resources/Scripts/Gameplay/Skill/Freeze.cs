using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 3f;
    Timer timer;
    private List<GameObject> objectsInTrigger = new List<GameObject>();
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 20f;
        timer.Run();
        //Invoke("FreezeObjects", 0.0f);

    }

    //void FreezeObjects()
    //{

    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
    //    if (colliders.Length > 0) Debug.Log("x");
    //    foreach (Collider2D collider in colliders)
    //    {
    //        if (collider.gameObject.CompareTag("attackers"))
    //        {
    //            AgentMoventMentMonster agent = collider.GetComponent<AgentMoventMentMonster>();

    //            if (agent != null && !agent.isAccessMovingTower)
    //            {
    //                float speed = agent.GetSpeed();
    //                //agent.AdjustSpeed((float)0.5);
    //                agent.AdjustSpeed((float)0.0, 3f);
    //                float speedAfter = agent.GetSpeed();

    //            }
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu một đối tượng khác đi qua trigger
        if (other.CompareTag("attackers"))
        {
           
            AgentMoventMentMonster agent = other.GetComponent<AgentMoventMentMonster>();
            //AgentMoventMent agent = other.GetComponent<AgentMoventMentMonster>();

            if (agent != null && !agent.isAccessMovingTower)
            {
               // Debug.Log("aggent");
                float speed = agent.GetSpeed();
                //agent.AdjustSpeed((float)0.5);
                agent.AdjustSpeed((float)8.0f);

                float speedAfter = agent.GetSpeed();

                // Xử lý tương tác khi đối tượng đi qua trigger
                //Debug.Log("Object entered the trigger:");
            }
            // Gọi hàm xử lý khác tại đây
        }
        else if (other.CompareTag("defenders"))
        {
            Debug.Log("def");
            AgentMoventMent agent = other.GetComponent<AgentMoventMent>();

            if (agent != null)
            {
                Debug.Log("aggent");
                float speed = agent.GetSpeed();
                //agent.AdjustSpeed((float)0.5);
                agent.AdjustSpeed((float)10.0f);

                float speedAfter = agent.GetSpeed();

            }


            // Xử lý tương tác khi đối tượng đi qua trigger
            Debug.Log("Object entered the trigger:");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra nếu một đối tượng khác đi qua trigger
        if (other.CompareTag("attackers"))
        {

            AgentMoventMentMonster agent = other.GetComponent<AgentMoventMentMonster>();
            //AgentMoventMent agent = other.GetComponent<AgentMoventMentMonster>();

            if (agent != null && !agent.isAccessMovingTower)
            {
                // Debug.Log("aggent");
                float speed = agent.GetSpeed();
                //agent.AdjustSpeed((float)0.5);
                agent.AdjustSpeed((float)2f);

                float speedAfter = agent.GetSpeed();

                // Xử lý tương tác khi đối tượng đi qua trigger
                //Debug.Log("Object entered the trigger:");
            }
            // Gọi hàm xử lý khác tại đây
        }
        else if (other.CompareTag("defenders"))
        {
            Debug.Log("def");
            AgentMoventMent agent = other.GetComponent<AgentMoventMent>();

            if (agent != null)
            {
                Debug.Log("aggent");
                float speed = agent.GetSpeed();
                //agent.AdjustSpeed((float)0.5);
                agent.AdjustSpeed((float)2f);

                float speedAfter = agent.GetSpeed();

            }


            // Xử lý tương tác khi đối tượng đi qua trigger
            Debug.Log("Object entered the trigger:");
        }
    }
    void Update()
    {
        if (timer.Finished)
        {

            Destroy(gameObject);

        }
    }

}






