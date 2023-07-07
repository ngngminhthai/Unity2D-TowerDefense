using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDefender : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 10;
    public float healingRate = 2;
    public float radius = 1f;
    Timer timer;

    private float currentHealth;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 10;
        timer.Run();
        currentHealth = maxHealth;
        InvokeRepeating("HealObjects", 0.0f, 2f);
    }

    void HealObjects()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        if (colliders.Length > 0) ;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("defenders"))
            {
                //Debug.Log("x");
                Unit unit = collider.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.TakeDamage(-healingRate);
                    //var animation = GameObject.Instantiate(rangeAnimation, gameObject.transform.position, Quaternion.identity);
                    //Tower.colliders.Remove(collider.gameObject);
                    //OnDrawGizmosSelected();
                }
               
            }
        }
    }
    private void Update()
    {
        if (timer.Finished)
        {
           
            Destroy(gameObject);
        }
    }

}
