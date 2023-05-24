using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
		EventManager.Initialize();
        ConfigurationUtils.Initialize();
        DifficultyUtils.Initialize();
	}
}
