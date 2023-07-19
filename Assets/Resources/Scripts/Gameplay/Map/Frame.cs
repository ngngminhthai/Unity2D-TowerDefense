using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float healingRate = 2;
    public float radius = 2f;
    Timer timer;


    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();
        
        InvokeRepeating("Effect", 0.0f, 2f);
    }

    public virtual void Effect()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
     
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("defenders")|| collider.gameObject.CompareTag("attackers"))
            {
                Unit unit = collider.GetComponent<Unit>();
                if (unit != null)
                {

                    unit.TakeDamage(healingRate);
                    //var animation = GameObject.Instantiate(rangeAnimation, gameObject.transform.position, Quaternion.identity);
                    //Tower.colliders.Remove(collider.gameObject);
                    //OnDrawGizmosSelected();
                }

            }
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
