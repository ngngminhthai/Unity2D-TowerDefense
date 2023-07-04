using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    // cached for efficiency
    Animator animator;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // destroy the game object if the explosion has finished its animation
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
