using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField]
    GameObject prefabsAnimation;
    Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Instantiate<GameObject>(prefabsAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
