using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDefender : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 10;
    public float healingRate = 2;
    public float radius = 7.5f;

  
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating("HealObjects", 0.0f, 2f);
    }

    void HealObjects()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        if (colliders.Length > 0) Debug.Log("x");
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("defenders"))
            {
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

}
