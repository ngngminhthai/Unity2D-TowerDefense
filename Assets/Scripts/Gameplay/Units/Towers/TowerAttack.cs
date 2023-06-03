using Assets.Scripts.Gameplay.Units.Defenders;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public float Range { get; set; }

    public Vector2 sourceDirection;

    public Vector2 targetDirection;

    public GameObject targetGameObjectPrefab;

    public Unit targetGameObject;
    public float Damage { get; set; }

    //boi vi game object co 2 collider
    private float count = 0;

    void Start()
    {
        count = 0;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //khi trigger se trigger 2 lan
    //    if (collision.gameObject.tag != sourceGameObject.tag)
    //    {
    //        //chi trigger 1 lan ,neu khong co thi damage se x2
    //        if (count == 1)
    //            return;
    //        if (collision.gameObject.tag == "attackers")
    //        {
    //            Debug.Log("Shoot at attacker");
    //            collision.gameObject.GetComponent<Attacker>().TakeDamage(Damage);
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<Defender>().TakeDamage(Damage);
    //            Destroy(gameObject);
    //        }
    //        count++;
    //    }
    //}

    private void Update()
    {
        // Debug.Log(Vector2.Distance(transform.position, targetDirection));
        if (Vector2.Distance(transform.position, targetDirection) < 1)
        {
            if (targetGameObject != null)
            {
                Debug.Log(Damage);
                targetGameObject.GetComponent<Unit>().TakeDamage(Damage);

            }
            Tower.colliders.Remove(targetGameObjectPrefab);
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
