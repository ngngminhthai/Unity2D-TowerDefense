using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Timer existTime;
    void Start()
    {
        existTime = gameObject.AddComponent<Timer>();
        existTime.Duration = 0.5f;
        existTime.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (existTime.Finished)
        {
            Destroy(gameObject);
        }
    }
}
