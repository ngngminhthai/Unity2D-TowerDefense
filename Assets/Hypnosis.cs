using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hypnosis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefabWarrior;
    [SerializeField]
    GameObject prefabArchery;



    private List<GameObject> triggeredAttackers = new List<GameObject>();

    int number;
    void Start()
    {
        
        int number = UnityEngine.Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu một đối tượng khác đi qua trigger
        GameObject attacker = other.gameObject;

        // Kiểm tra nếu attacker đã được trigger trước đó
        if (triggeredAttackers.Contains(attacker))
        {
            return; // Đã kích hoạt rồi, không thực hiện gì nữa
        }
        if (attacker.CompareTag("attackers"))
        {
            GameObject agent = other.gameObject;
            //AgentMoventMentMonster agent = other.GetComponent<AgentMoventMentMonster>();
            //AgentMoventMent agent = other.GetComponent<AgentMoventMentMonster>();

            if (agent != null)
            {
                Vector3 vector3 = agent.transform.position;

                Destroy(agent);
                if (number == 1)
                {
                    Instantiate<GameObject>(prefabWarrior, vector3, Quaternion.identity);
                }
                else
                {
                    Instantiate<GameObject>(prefabArchery, vector3, Quaternion.identity);
                }
            }
            triggeredAttackers.Add(attacker);
            // Gọi hàm xử lý khác tại đây
        }
        

    }
}
