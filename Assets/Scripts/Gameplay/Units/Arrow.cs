using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 sourceDirection;
    // Update is called once per frame
    public float radius;
    // update my email
    void Start()
    {

    }

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
        if (collision.gameObject.tag != "attackers")
        {
            Destroy(gameObject);
        }
    }
}
