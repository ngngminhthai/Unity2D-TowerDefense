using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AOEAttack : MonoBehaviour
{
    // Start is called before the first frame update

    Timer existTime;

    private bool hasExecuted = false;
    public float radius = 5f;
    void Start()
    {
     //   Debug.Log("attack");
        existTime = gameObject.AddComponent<Timer>();
        existTime.Duration = 2f;
        existTime.Run();
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //   // Debug.Log("att");
    //    if (other.gameObject.CompareTag("defenders")) // Xác định va chạm với Game Object có nhãn "Enemy"
    //    {

    //        Vector3 explosionPos = transform.position; // Lấy vị trí của Prefab AOE attack
    //        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius); // Lấy danh sách các Collider trong bán kính của vùng AOE

    //        foreach (Collider2D hit in colliders) // Duyệt danh sách các Collider và gây ảnh hưởng AOE damage cho từng Game Object
    //        {
    //            if (hit.gameObject.CompareTag("defenders"))
    //            {
    //                Defender enemy = hit.GetComponent<Defender>(); // Lấy component Enemy từ Game Object
    //                if (enemy != null) // Nếu Game Object có component Enemy thì gây sát thương
    //                {
    //                   // Debug.Log("getdame");
    //                    enemy.TakeDamage(Monitor.damage);
    //                }
    //            }
    //        }
    //    }
    //    if (other.gameObject.CompareTag("tower")) // Xác định va chạm với Game Object có nhãn "Enemy"
    //    {
    //        Debug.Log("attower");
    //        Vector3 explosionPos = transform.position; // Lấy vị trí của Prefab AOE attack
    //        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius); // Lấy danh sách các Collider trong bán kính của vùng AOE

    //        foreach (Collider2D hit in colliders) // Duyệt danh sách các Collider và gây ảnh hưởng AOE damage cho từng Game Object
    //        {
    //            if (hit.gameObject.CompareTag("tower"))
    //            {
    //                Tower enemy = hit.GetComponent<Tower>(); // Lấy component Enemy từ Game Object
    //                if (enemy != null) // Nếu Game Object có component Enemy thì gây sát thương
    //                {
    //                    Debug.Log("getdame");
    //                    enemy.TakeDamage(Monitor.damage);
    //                }
    //            }
    //        }
    //    }
    //}
    // Update is called once per frame
    void ExampleFunction()
    {
        if (!hasExecuted)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.CompareTag("defenders"))
                {
                    Defender health = collider.gameObject.GetComponent<Defender>();
                    if (health != null)
                    {
                        health.TakeDamage(5f);
                    }
                }
                //Debug.Log("aaaa");
            }
            hasExecuted = true;
        }
    }
    void Update()
    {
      ExampleFunction();
        if (existTime.Finished)
        {
            Destroy(gameObject);
        }
    }
}
