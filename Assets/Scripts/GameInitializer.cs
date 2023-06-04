using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Awake()
    {
        EventManager.Initialize();
        ConfigurationUtils.Initialize();
    }
    void Start()
    {
        //  EventManager.Initialize();
        //ConfigurationUtils.Initialize();
        DifficultyUtils.Initialize();
    }

   
}
