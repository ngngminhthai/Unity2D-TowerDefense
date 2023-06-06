using Assets.Scripts.Gameplay.Units.Defenders;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public float Range { get; set; }

    public GameObject sourceGameObject;

    public Vector2 targetDirection;

    public GameObject targetGameObjectPrefab;

    public Unit targetGameObject;
    public float Damage { get; set; }


    [SerializeField]
    public GameObject reachingAnimation;

    //boi vi game object co 2 collider
    private float count = 0;

    void Start()
    {
        count = 0;
    }

    private void Update()
    {
        // Debug.Log(Vector2.Distance(transform.position, targetDirection));
        if (Vector2.Distance(transform.position, targetDirection) < 1)
        {
            if (targetGameObject != null)
            {
                targetGameObject.GetComponent<Unit>().TakeDamage(Damage);
                GameObject.Instantiate(reachingAnimation, targetGameObject.transform.position, Quaternion.identity);
                DoesEffectBehaviour();
            }

            //Tower.colliders.Remove(targetGameObjectPrefab);
            Tower.colliders.Clear();
            Destroy(gameObject);
        }
    }

    public virtual void DoesEffectBehaviour()
    {

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
