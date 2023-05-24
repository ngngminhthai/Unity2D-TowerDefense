using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides utility access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	#region Fields

	static ConfigurationData configurationData;

	#endregion

	#region Properties

	/// <summary>
	/// Gets the number of seconds in a game
	/// </summary>
	public static int TotalGameSeconds
    {
		get { return configurationData.TotalGameSeconds; }
	}

	/// <summary>
	/// Gets how many units the burger moves in a second
	/// </summary>
	/// <value>burger move units per second</value>
	public static float BurgerMoveUnitsPerSecond
    {
		get { return configurationData.BurgerMoveUnitsPerSecond; }
	}

	/// <summary>
	/// Gets the min spawn delay for teddy bear spawning
	/// </summary>
	/// <value>minimum spawn delay</value>
	public static float MinSpawnDelay
    {
		get { return DifficultyUtils.MinSpawnDelay; }
	}

	/// <summary>
	/// Gets the max spawn delay for teddy bear spawning
	/// </summary>
	/// <value>maximum spawn delay</value>
	public static float MaxSpawnDelay
    {
		get { return DifficultyUtils.MaxSpawnDelay; }
	}
		
	/// <summary>
	/// Gets the min impulse force for teddy bears
	/// </summary>
	/// <value>minimum impulse force</value>
	public static float MinImpulseForce
    {
		get { return DifficultyUtils.MinImpulseForce; }
	}

    /// <summary>
    /// Gets the max impulse force for teddy bears
    /// </summary>
    /// <value>maximum impulse force</value>
    public static float MaxImpulseForce
    {
        get { return DifficultyUtils.MaxImpulseForce; }
    }

	/// <summary>
	/// Gets the max number of teddy bears
	/// </summary>
	/// <value>max number of teddy bears</value>
	public static int MaxNumBears
    {
		get { return DifficultyUtils.MaxNumBears; }
	}

	/// <summary>
	/// Gets the amount of damage a teddy bear inflicts
	/// </summary>
	/// <value>bear damage</value>
	public static int BearDamage
    {
		get { return configurationData.BearDamage; }
	}

	/// <summary>
	/// Gets the impulse force to apply to french fries
	/// </summary>
	/// <value>french fries impulse force</value>
	public static float FrenchFriesImpulseForce
    {
		get { return configurationData.FrenchFriesImpulseForce; }
	}

	/// <summary>
	/// Gets the number of seconds the burger takes
	/// to cool down so it can shoot again
	/// </summary>
	/// <value>burger cooldown seconds</value>
	public static float BurgerCooldownSeconds
    {
		get { return configurationData.BurgerCooldownSeconds; }
	}

	/// <summary>
	/// Gets how many points a bear is worth
	/// </summary>
	/// <value>bear points</value>
	public static int BearPoints
    {
		get { return configurationData.BearPoints; }
	}

	/// <summary>
	/// Gets the impulse force to apply to teddy bear projectiles
	/// </summary>
	/// <value>teddy bear projectile impulse force</value>
	public static float TeddyBearProjectileImpulseForce
    {
		get { return configurationData.TeddyBearProjectileImpulseForce; }
	}

	/// <summary>
	/// Gets the minimum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>bear minimum shot delay</value>
	public static float BearMinShotDelay
    {
		get { return DifficultyUtils.BearMinShotDelay; }
	}

	/// <summary>
	/// Gets the maximum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>bear maximum shot delay</value>
	public static float BearMaxShotDelay
    {
		get { return DifficultyUtils.BearMaxShotDelay; }
	}
		
	/// <summary>
	/// Gets the amount of damage a teddy bear projectile inflicts
	/// </summary>
	/// <value>bear damage</value>
	public static int BearProjectileDamage
    {
		get { return configurationData.BearProjectileDamage; }
	}

    #endregion

    #region Properties that should only be used by DifficultyUtils

    /// <summary>
    /// Gets the easy min spawn delay for teddy bear spawning
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy minimum spawn delay</value>
    public static float EasyMinSpawnDelay
    {
		get { return configurationData.EasyMinSpawnDelay; }
	}

    /// <summary>
    /// Gets the medium min spawn delay for teddy bear spawning
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium minimum spawn delay</value>
    public static float MediumMinSpawnDelay
    {
		get { return configurationData.MediumMinSpawnDelay; }
	}

    /// <summary>
    /// Gets the hard min spawn delay for teddy bear spawning
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard minimum spawn delay</value>
    public static float HardMinSpawnDelay
    {
		get { return configurationData.HardMinSpawnDelay; }
	}

    /// <summary>
    /// Gets the easy max spawn delay for teddy bear spawning
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy maximum spawn delay</value>
    public static float EasyMaxSpawnDelay
    {
		get { return configurationData.EasyMaxSpawnDelay; }
	}

    /// <summary>
    /// Gets the medium max spawn delay for teddy bear spawning
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium maximum spawn delay</value>
    public static float MediumMaxSpawnDelay
    {
		get { return configurationData.MediumMaxSpawnDelay; }
	}

    /// <summary>
    /// Gets the hard max spawn delay for teddy bear spawning
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard maximum spawn delay</value>
    public static float HardMaxSpawnDelay
    {
		get { return configurationData.HardMaxSpawnDelay; }
	}

    /// <summary>
    /// Gets the easy min impulse force for teddy bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy minimum impulse force</value>
    public static float EasyMinImpulseForce
    {
		get { return configurationData.EasyMinImpulseForce; }
	}

    /// <summary>
    /// Gets the medium min impulse force for teddy bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium minimum impulse force</value>
    public static float MediumMinImpulseForce
    {
		get { return configurationData.MediumMinImpulseForce; }
	}

    /// <summary>
    /// Gets the hard min impulse force for teddy bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard minimum impulse force</value>
    public static float HardMinImpulseForce
    {
		get { return configurationData.HardMinImpulseForce; }
	}

    /// <summary>
    /// Gets the max impulse force for teddy bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy max impulse force</value>
    public static float EasyMaxImpulseForce
    {
		get { return configurationData.EasyMaxImpulseForce; }
	}

    /// <summary>
    /// Gets the medium max impulse force for teddy bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium max impulse force</value>
    public static float MediumMaxImpulseForce
    {
		get { return configurationData.MediumMaxImpulseForce; }
	}

    /// <summary>
    /// Gets the hard max impulse force for teddy bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard max impulse force</value>
    public static float HardMaxImpulseForce
    {
		get { return configurationData.HardMaxImpulseForce; }
	}

    /// <summary>
    /// Gets the easy max number of bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy max number bears</value>
    public static int EasyMaxNumBears
    {
		get { return configurationData.EasyMaxNumBears; }
	}

    /// <summary>
    /// Gets the medium max number of bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium max number bears</value>
    public static int MediumMaxNumBears
    {
		get { return configurationData.MediumMaxNumBears; }
	}

    /// <summary>
    /// Gets the hard max number of bears
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard max number bears</value>
    public static int HardMaxNumBears
    {
		get { return configurationData.HardMaxNumBears; }
	}

    /// <summary>
    /// Gets the easy minimum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy bear minimum shot delay</value>
    public static float EasyBearMinShotDelay
    {
		get { return configurationData.EasyBearMinShotDelay; }
	}

    /// <summary>
    /// Gets the medium minimum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium bear minimum shot delay</value>
    public static float MediumBearMinShotDelay
    {
		get { return configurationData.MediumBearMinShotDelay; }
	}

    /// <summary>
    /// Gets the hard minimum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard bear minimum shot delay</value>
    public static float HardBearMinShotDelay
    {
		get { return configurationData.HardBearMinShotDelay; }
	}

    /// <summary>
    /// Gets the easy maximum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy bear maximum shot delay</value>
    public static float EasyBearMaxShotDelay
    {
		get { return configurationData.EasyBearMaxShotDelay; }
	}

    /// <summary>
    /// Gets the medium maximum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium bear maximum shot delay</value>
    public static float MediumBearMaxShotDelay
    {
		get { return configurationData.MediumBearMaxShotDelay; }
	}

    /// <summary>
    /// Gets the hard maximum delay for a teddy bear to shoot
    /// a teddy bear projectile
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard bear maximum shot delay</value>
    public static float HardBearMaxShotDelay
    {
		get { return configurationData.HardBearMaxShotDelay; }
	}

    /// <summary>
    /// Gets the easy delay for a teddy bear to
    /// move toward the burger
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy bear homing delay</value>
    public static float EasyBearHomingDelay
    {
		get { return configurationData.EasyBearHomingDelay; }
	}

    /// <summary>
    /// Gets the medium delay for a teddy bear to
    /// move toward the burger
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium bear homing delay</value>
    public static float MediumBearHomingDelay
    {
		get { return configurationData.MediumBearHomingDelay; }
	}

    /// <summary>
    /// Gets the hard delay for a teddy bear to
    /// move toward the burger
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard bear homing delay</value>
    public static float HardBearHomingDelay
    {
		get { return configurationData.HardBearHomingDelay; }
	}

    /// <summary>
    /// Gets the easy delay for a teddy bear projectile 
    /// to move toward the burger
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>easy bear projectile homing delay</value>
    public static float EasyBearProjectileHomingDelay
    {
		get { return configurationData.EasyBearProjectileHomingDelay; }
	}

    /// <summary>
    /// Gets the medium delay for a teddy bear projectile
    /// to move toward the burger
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>medium bear projectile homing delay</value>
    public static float MediumBearProjectileHomingDelay
    {
		get { return configurationData.MediumBearProjectileHomingDelay; }
	}

    /// <summary>
    /// Gets the hard delay for a teddy bear projectile
    /// to move toward the burger
    /// This property should only be used by DifficultyUtils
    /// </summary>
    /// <value>hard bear projectile homing delay</value>
    public static float HardBearProjectileHomingDelay
    {
		get { return configurationData.HardBearProjectileHomingDelay; }
	}

    /// <summary>
    /// Gets the homing delay for the given tag
    /// </summary>
    /// <returns>homing delay</returns>
    /// <param name="tag">tag</param>
    public static float GetHomingDelay(string tag)
    {
        return DifficultyUtils.GetHomingDelay(tag);
    }

	#endregion

	#region Public methods

	/// <summary>
	/// Initializes the configuration data by creating the ConfigurationData object 
	/// </summary>
	public static void Initialize()
	{
        configurationData = new ConfigurationData();
	}

	#endregion
}
