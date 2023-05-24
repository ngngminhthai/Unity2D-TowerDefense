using UnityEngine.SceneManagement;

/// <summary>
/// Provides difficulty-specific utilities
/// </summary>
public static class DifficultyUtils
{
    #region Fields

    static Difficulty difficulty;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the min spawn delay for teddy bear spawning
    /// </summary>
    /// <value>minimum spawn delay</value>
    public static float MinSpawnDelay
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinSpawnDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinSpawnDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinSpawnDelay;
                default:
                    return ConfigurationUtils.EasyMinSpawnDelay;
            }
        }
    }

    /// <summary>
    /// Gets the max spawn delay for teddy bear spawning
    /// </summary>
    /// <value>maximum spawn delay</value>
    public static float MaxSpawnDelay
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxSpawnDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxSpawnDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxSpawnDelay;
                default:
                    return ConfigurationUtils.EasyMaxSpawnDelay;
            }
        }
    }

    /// <summary>
    /// Gets the min impulse force for teddy bears
    /// </summary>
    /// <value>minimum impulse force</value>
    public static float MinImpulseForce
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinImpulseForce;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinImpulseForce;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinImpulseForce;
                default:
                    return ConfigurationUtils.EasyMinImpulseForce;
            }
        }
    }

    /// <summary>
    /// Gets the max impulse force for teddy bears
    /// </summary>
    /// <value>max impulse force</value>
    public static float MaxImpulseForce
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxImpulseForce;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxImpulseForce;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxImpulseForce;
                default:
                    return ConfigurationUtils.EasyMaxImpulseForce;
            }
        }
    }

    /// <summary>
    /// Gets the max number of teddy bears
    /// </summary>
    /// <value>max number of teddy bears</value>
    public static int MaxNumBears
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxNumBears;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxNumBears;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxNumBears;
                default:
                    return ConfigurationUtils.EasyMaxNumBears;
            }
        }
    }

    /// <summary>
    /// Gets the minimum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// </summary>
    /// <value>bear minimum shot delay</value>
    public static float BearMinShotDelay
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBearMinShotDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBearMinShotDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBearMinShotDelay;
                default:
                    return ConfigurationUtils.EasyBearMinShotDelay;
            }
        }
    }

    /// <summary>
    /// Gets the maximum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// </summary>
    /// <value>bear maximum shot delay</value>
    public static float BearMaxShotDelay
    {
        get
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBearMaxShotDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBearMaxShotDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBearMaxShotDelay;
                default:
                    return ConfigurationUtils.EasyBearMaxShotDelay;
            }
        }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Initializes the difficulty utils
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddListener(EventName.GameStartedEvent,
            HandleGameStartedEvent);
    }

    /// <summary>
    /// Gets the homing delay for the given tag for
    /// the current game difficulty
    /// </summary>
    /// <returns>homing delay</returns>
    /// <param name="tag">tag</param>
    public static float GetHomingDelay(string tag)
    {
        if (tag == "TeddyBear")
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBearHomingDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBearHomingDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBearHomingDelay;
                default:
                    return ConfigurationUtils.EasyBearHomingDelay;
            }

        }
        else
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBearProjectileHomingDelay;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBearProjectileHomingDelay;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBearProjectileHomingDelay;
                default:
                    return ConfigurationUtils.EasyBearProjectileHomingDelay;
            }
        }
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Sets the difficulty and starts the game
    /// </summary>
    /// <param name="intDifficulty">int value for difficulty</param>
    static void HandleGameStartedEvent(int intDifficulty)
    {
        difficulty = (Difficulty)intDifficulty;
        //SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene("Gameplay");
    }

    #endregion
}
