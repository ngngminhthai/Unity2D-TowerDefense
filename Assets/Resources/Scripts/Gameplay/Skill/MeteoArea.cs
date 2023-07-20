using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoArea : MonoBehaviour
{


    [SerializeField]
    GameObject prefabFire;



    private List<GameObject> triggeredAttackers = new List<GameObject>();

    
    void Start()
    {

        
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
            //GameObject agent = other.gameObject;
            AgentMoventMentMonster agent = attacker.GetComponent<AgentMoventMentMonster>();
            Unit unit = attacker.GetComponent<Unit>();
            //AgentMoventMent agent = other.GetComponent<AgentMoventMentMonster>();

            if (agent != null)
            {
                float damage = unit.MaxHitPoint * 40 /100;
                agent.FireAction(10, 10f, prefabFire);

              
            }
            triggeredAttackers.Add(attacker);
            // Gọi hàm xử lý khác tại đây
        }

    }
}
