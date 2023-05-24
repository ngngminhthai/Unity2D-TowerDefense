using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public class ConfigurationData
{
	#region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    Dictionary<ConfigurationDataValueName, float> values =
        new Dictionary<ConfigurationDataValueName, float>();

	#endregion

	#region Properties

	/// <summary>
	/// Gets the number of seconds in a game
	/// </summary>
	public int TotalGameSeconds
    {
        get { return (int)values[ConfigurationDataValueName.TotalGameSeconds]; }
	}

	/// <summary>
	/// Gets how many units the burger moves in a second
	/// </summary>
	/// <value>burger move units per second</value>
	public float BurgerMoveUnitsPerSecond
    {
        get { return values[ConfigurationDataValueName.BurgerMoveUnitsPerSecond]; }
	}

	/// <summary>
	/// Gets the easy min spawn delay for teddy bear spawning
	/// </summary>
	/// <value>easy minimum spawn delay</value>
	public float EasyMinSpawnDelay
    {
        get { return values[ConfigurationDataValueName.EasyMinSpawnDelay]; }
	}

	/// <summary>
	/// Gets the medium min spawn delay for teddy bear spawning
	/// </summary>
	/// <value>medium minimum spawn delay</value>
	public float MediumMinSpawnDelay
    {
        get { return values[ConfigurationDataValueName.MediumMinSpawnDelay]; }
	}

	/// <summary>
	/// Gets the hard min spawn delay for teddy bear spawning
	/// </summary>
	/// <value>hard minimum spawn delay</value>
	public float HardMinSpawnDelay
    {
        get { return values[ConfigurationDataValueName.HardMinSpawnDelay]; }
	}

	/// <summary>
	/// Gets the easy max spawn delay for teddy bear spawning
	/// </summary>
	/// <value>easy maximum spawn delay</value>
	public float EasyMaxSpawnDelay
    {
        get { return values[ConfigurationDataValueName.EasyMaxSpawnDelay]; }
	}

	/// <summary>
	/// Gets the medium max spawn delay for teddy bear spawning
	/// </summary>
	/// <value>medium maximum spawn delay</value>
	public float MediumMaxSpawnDelay
    {
        get { return values[ConfigurationDataValueName.MediumMaxSpawnDelay]; }
	}

	/// <summary>
	/// Gets the hard max spawn delay for teddy bear spawning
	/// </summary>
	/// <value>hard maximum spawn delay</value>
	public float HardMaxSpawnDelay
    {
        get { return values[ConfigurationDataValueName.HardMaxSpawnDelay]; }
	}

	/// <summary>
	/// Gets the easy min impulse force for teddy bears
	/// </summary>
	/// <value>easy minimum impulse force</value>
	public float EasyMinImpulseForce
    {
        get { return values[ConfigurationDataValueName.EasyMinImpulseForce]; }
	}

	/// <summary>
	/// Gets the medium min impulse force for teddy bears
	/// </summary>
	/// <value>medium minimum impulse force</value>
	public float MediumMinImpulseForce
    {
        get { return values[ConfigurationDataValueName.MediumMinImpulseForce]; }
	}

	/// <summary>
	/// Gets the hard min impulse force for teddy bears
	/// </summary>
	/// <value>hard minimum impulse force</value>
	public float HardMinImpulseForce
    {
        get { return values[ConfigurationDataValueName.HardMinImpulseForce]; }
	}

	/// <summary>
	/// Gets the easy max impulse force for teddy bears
	/// </summary>
	/// <value>easy max impulse force</value>
	public float EasyMaxImpulseForce
    {
        get { return values[ConfigurationDataValueName.EasyMaxImpulseForce]; }
	}

    /// <summary>
    /// Gets the medium max impulse force for teddy bears
    /// </summary>
    /// <value>medium max impulse force</value>
    public float MediumMaxImpulseForce
    {
        get { return values[ConfigurationDataValueName.MediumMaxImpulseForce]; }
	}

    /// <summary>
    /// Gets the hard max impulse force for teddy bears
    /// </summary>
    /// <value>hard max impulse force</value>
    public float HardMaxImpulseForce
    {
        get { return values[ConfigurationDataValueName.HardMaxImpulseForce]; }
	}

	/// <summary>
	/// Gets the easy max number of bears
	/// </summary>
	/// <value>easy max number bears</value>
	public int EasyMaxNumBears
    {
        get { return (int)values[ConfigurationDataValueName.EasyMaxNumBears]; }
	}

	/// <summary>
	/// Gets the medium max number of bears
	/// </summary>
	/// <value>medium max number bears</value>
	public int MediumMaxNumBears
    {
        get { return (int)values[ConfigurationDataValueName.MediumMaxNumBears]; }
	}

	/// <summary>
	/// Gets the hard max number of bears
	/// </summary>
	/// <value>hard max number bears</value>
	public int HardMaxNumBears
    {
        get { return (int)values[ConfigurationDataValueName.HardMaxNumBears]; }
	}

	/// <summary>
	/// Gets the amount of damage a teddy bear inflicts
	/// </summary>
	/// <value>bear damage</value>
	public int BearDamage
    {
        get { return (int)values[ConfigurationDataValueName.BearDamage]; }
	}

	/// <summary>
	/// Gets the impulse force to apply to french fries
	/// </summary>
	/// <value>french fries impulse force</value>
	public float FrenchFriesImpulseForce
    {
        get { return values[ConfigurationDataValueName.FrenchFriesImpulseForce]; }
	}

	/// <summary>
	/// Gets the number of seconds the burger takes
	/// to cool down so it can shoot again
	/// </summary>
	/// <value>burger cooldown seconds</value>
	public float BurgerCooldownSeconds
    {
        get { return values[ConfigurationDataValueName.BurgerCooldownSeconds]; }
	}

	/// <summary>
	/// Gets how many points a bear is worth
	/// </summary>
	/// <value>bear points</value>
	public int BearPoints
    {
        get { return (int)values[ConfigurationDataValueName.BearPoints]; }
	}

	/// <summary>
	/// Gets the impulse force to apply to teddy bear projectiles
	/// </summary>
	/// <value>teddy bear projectile impulse force</value>
	public float TeddyBearProjectileImpulseForce
    {
        get { return values[ConfigurationDataValueName.TeddyBearProjectileImpulseForce]; }
	}
		
	/// <summary>
	/// Gets the easy minimum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>easy bear minimum shot delay</value>
	public float EasyBearMinShotDelay
    {
        get { return values[ConfigurationDataValueName.EasyBearMinShotDelay]; }
	}

	/// <summary>
	/// Gets the medium minimum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>medium bear minimum shot delay</value>
	public float MediumBearMinShotDelay
    {
        get { return values[ConfigurationDataValueName.MediumBearMinShotDelay]; }
	}

	/// <summary>
	/// Gets the hard minimum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>hard bear minimum shot delay</value>
	public float HardBearMinShotDelay
    {
        get { return values[ConfigurationDataValueName.HardBearMinShotDelay]; }
	}

	/// <summary>
	/// Gets the easy maximum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>easy bear maximum shot delay</value>
	public float EasyBearMaxShotDelay
    {
        get { return values[ConfigurationDataValueName.EasyBearMaxShotDelay]; }
	}

	/// <summary>
	/// Gets the medium maximum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>medium bear maximum shot delay</value>
	public float MediumBearMaxShotDelay
    {
        get { return values[ConfigurationDataValueName.MediumBearMaxShotDelay]; }
	}

	/// <summary>
	/// Gets the hard maximum delay for a teddy bear to shoot
	/// a teddy bear projectile
	/// </summary>
	/// <value>hard bear maximum shot delay</value>
	public float HardBearMaxShotDelay
    {
        get { return values[ConfigurationDataValueName.HardBearMaxShotDelay]; }
	}

	/// <summary>
	/// Gets the amount of damage a teddy bear projectile inflicts
	/// </summary>
	/// <value>bear damage</value>
	public int BearProjectileDamage
    {
        get { return (int)values[ConfigurationDataValueName.BearProjectileDamage]; }
	}

	/// <summary>
	/// Gets the easy delay for a teddy bear to
	/// move toward the burger
	/// </summary>
	/// <value>easy bear homing delay</value>
	public float EasyBearHomingDelay
    {
        get { return values[ConfigurationDataValueName.EasyBearHomingDelay]; }
	}

	/// <summary>
	/// Gets the medium delay for a teddy bear to
	/// move toward the burger
	/// </summary>
	/// <value>medium bear homing delay</value>
	public float MediumBearHomingDelay
    {
        get { return values[ConfigurationDataValueName.MediumBearHomingDelay]; }
	}

	/// <summary>
	/// Gets the hard delay for a teddy bear to
	/// move toward the burger
	/// </summary>
	/// <value>hard bear homing delay</value>
	public float HardBearHomingDelay
    {
        get { return values[ConfigurationDataValueName.HardBearHomingDelay]; }
	}

	/// <summary>
	/// Gets the easy delay for a teddy bear projectile 
	/// to move toward the burger
	/// </summary>
	/// <value>easy bear projectile homing delay</value>
	public float EasyBearProjectileHomingDelay
    {
        get { return values[ConfigurationDataValueName.EasyBearProjectileHomingDelay]; }
	}

	/// <summary>
	/// Gets the medium delay for a teddy bear projectile
	/// to move toward the burger
	/// </summary>
	/// <value>medium bear projectile homing delay</value>
	public float MediumBearProjectileHomingDelay
    {
        get { return values[ConfigurationDataValueName.MediumBearProjectileHomingDelay]; }
	}

	/// <summary>
	/// Gets the hard delay for a teddy bear projectile
	/// to move toward the burger
	/// </summary>
	/// <value>hard bear projectile homing delay</value>
	public float HardBearProjectileHomingDelay
    {
        get { return values[ConfigurationDataValueName.HardBearProjectileHomingDelay]; }
	}

	#endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // populate values
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                string[] tokens = currentLine.Split(',');
                ConfigurationDataValueName valueName = 
                    (ConfigurationDataValueName)Enum.Parse(
                        typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1]));
                currentLine = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            // set default values if something went wrong
            SetDefaultValues();
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    /// <summary>
    /// Sets the configuration data fields to default values
    /// csv string
    /// </summary>
    void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.TotalGameSeconds, 30);
        values.Add(ConfigurationDataValueName.BurgerMoveUnitsPerSecond, 5);
        values.Add(ConfigurationDataValueName.BearDamage, 10);
        values.Add(ConfigurationDataValueName.BearProjectileDamage, 5);
        values.Add(ConfigurationDataValueName.FrenchFriesImpulseForce, 10);
        values.Add(ConfigurationDataValueName.BurgerCooldownSeconds, 0.5f);
        values.Add(ConfigurationDataValueName.BearPoints, 10);
        values.Add(ConfigurationDataValueName.TeddyBearProjectileImpulseForce, 5);
        values.Add(ConfigurationDataValueName.EasyMinSpawnDelay, 1);
        values.Add(ConfigurationDataValueName.EasyMaxSpawnDelay, 2);
        values.Add(ConfigurationDataValueName.EasyMinImpulseForce, 3);
        values.Add(ConfigurationDataValueName.EasyMaxImpulseForce, 4);
        values.Add(ConfigurationDataValueName.EasyMaxNumBears, 5);
        values.Add(ConfigurationDataValueName.EasyBearMinShotDelay, 1.5f);
        values.Add(ConfigurationDataValueName.EasyBearMaxShotDelay, 2.5f);
        values.Add(ConfigurationDataValueName.EasyBearHomingDelay, 2);
        values.Add(ConfigurationDataValueName.EasyBearProjectileHomingDelay, 0.5f);
        values.Add(ConfigurationDataValueName.MediumMinSpawnDelay, 0.5f);
        values.Add(ConfigurationDataValueName.MediumMaxSpawnDelay, 2);
        values.Add(ConfigurationDataValueName.MediumMinImpulseForce, 2.5f);
        values.Add(ConfigurationDataValueName.MediumMaxImpulseForce, 5);
        values.Add(ConfigurationDataValueName.MediumMaxNumBears, 7);
        values.Add(ConfigurationDataValueName.MediumBearMinShotDelay, 1);
        values.Add(ConfigurationDataValueName.MediumBearMaxShotDelay, 2);
        values.Add(ConfigurationDataValueName.MediumBearHomingDelay, 1.25f);
        values.Add(ConfigurationDataValueName.MediumBearProjectileHomingDelay, 0.35f);
        values.Add(ConfigurationDataValueName.HardMinSpawnDelay, 0.25f);
        values.Add(ConfigurationDataValueName.HardMaxSpawnDelay, 1);
        values.Add(ConfigurationDataValueName.HardMinImpulseForce, 3);
        values.Add(ConfigurationDataValueName.HardMaxImpulseForce, 6);
        values.Add(ConfigurationDataValueName.HardMaxNumBears, 10);
        values.Add(ConfigurationDataValueName.HardBearMinShotDelay, 0.5f);
        values.Add(ConfigurationDataValueName.HardBearMaxShotDelay, 1.5f);
        values.Add(ConfigurationDataValueName.HardBearHomingDelay, 0.5f);
        values.Add(ConfigurationDataValueName.HardBearProjectileHomingDelay, 0.2f);
    }
}