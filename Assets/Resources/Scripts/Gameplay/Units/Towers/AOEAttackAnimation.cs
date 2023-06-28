using UnityEngine;


public class AOEAttackAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    Timer existTime;

    private bool hasExecuted = false;
    public float radius = 5f;
    void Start()
    {
        existTime = gameObject.AddComponent<Timer>();
        existTime.Duration = 1f;
        existTime.Run();
    }

    void Update()
    {
        if (existTime.Finished)
        {
            Destroy(gameObject);
        }
    }
}

