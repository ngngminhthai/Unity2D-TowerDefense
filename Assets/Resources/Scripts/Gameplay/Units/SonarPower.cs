using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarPower : MonoBehaviour
{
    public Vector2 sourceDirection;
    // Update is called once per frame
    public float radius;
    void Start()
    {
        if (Vector2.Distance(sourceDirection, transform.position) - radius > 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    private void Update()
    {
        if (Vector2.Distance(sourceDirection, transform.position) - radius > 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag != "deffenders")
        {
            Destroy(gameObject);
        }
    }
}
