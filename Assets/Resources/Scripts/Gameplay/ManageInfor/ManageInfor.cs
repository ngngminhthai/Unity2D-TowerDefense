using UnityEngine;

public class ManageInfor : MonoBehaviour
{
    // archery
    public static float ArcheryDamagePer = 0.45f;
    public static float ArcheryHitpointsPer = 0.45f;


    public static float ArcheryRange = 3f;
    public static float ArcheryRelectedRange = 0.5f;
    public static float ArcheryDefautDamage = 7f;
    public static float ArcheryDefautHitpoint = 40f;

    public static float ArcheryDamage = 7f;
    public static float ArcheryHitPoint = 40;
    public static float ArcherySpeed = 5f;

    public static float ArcheryStrength = (ArcheryDamage + ArcheryHitPoint / 2) + (1 + ArcherySpeed / 3);
    public static void LevelUpArchery()
    {
        ArcheryLevel = ArcheryLevel + 1;
        ArcheryDamage = ArcheryDefautDamage + ArcheryDefautDamage * ArcheryDamagePer * ArcheryLevel;
        ArcheryHitPoint = ArcheryDefautHitpoint + ArcheryHitPoint * ArcheryHitpointsPer * ArcheryLevel;

        ArcheryStrength = (ArcheryHitPoint / 2 + ArcheryDamage) + (1 + ArcherySpeed / 3);


    }
    public static int ArcheryLevel = 0;
    // Warior
    public static float WarriorDamagePer = 0.45f;
    public static float WarriorHitpointsPer = 0.45f;




    public static float WarriorRange = 3f;
    public static float WarriorSelectedRange = 0.5f;
    public static float WarriorDefautDamage = 7f;
    public static float WarriorDefautHitpoint = 50f;

    public static float WarriorDamage = 7f;
    public static float WarriorHitPoint = 50f;
    public static float WarriorSpeed = 5f;

    public static float WarriorStrength = (WarriorDamage + WarriorHitPoint / 2) + (1 + WarriorSpeed / 3);

    public static int WarriorLevel = 0;
    public static void LevelUpWarrior()
    {
        WarriorLevel = WarriorLevel + 1;
        WarriorDamage = WarriorDefautDamage + WarriorDefautDamage * WarriorDamagePer * WarriorLevel;
        WarriorHitPoint = WarriorDefautHitpoint + WarriorDefautHitpoint * WarriorHitpointsPer * WarriorLevel;

        WarriorStrength = (WarriorHitPoint / 2 + WarriorDamage) + (1 + WarriorSpeed / 3);


    }

    // Xena
    public static float XenaDamagePer = 0.45f;
    public static float XenaHitpointsPer = 0.45f;




    public static float XenaRange = 3f;
    public static float XenaSelectedRange = 0.5f;
    public static float XenaDefautDamage = 7f;
    public static float XenaDefautHitpoint = 50f;

    public static float XenaDamage = 7f;
    public static float XenaHitPoint = 50f;
    public static float XenaSpeed = 5f;

    public static float XenaStrength = (XenaDamage + XenaHitPoint / 2) + (1 + XenaSpeed / 3);

    public static int XenaLevel = 0;
    public static void LevelUpXena()
    {
        XenaLevel = XenaLevel + 1;
        XenaDamage = XenaDefautDamage + XenaDefautDamage * XenaDamagePer * XenaLevel;
        XenaHitPoint = XenaDefautHitpoint + XenaDefautHitpoint * XenaHitpointsPer * XenaLevel;

        XenaStrength = (XenaHitPoint / 2 + XenaDamage) + (1 + XenaSpeed / 3);
    }

    // Banshee
    public static float BansheeRange = 3f;
    public static float BansheeBaseHitPoints = 30f;
    public static float BansheeSelectedRange = 1.5f;
    public static float BansheeDamage = 3f;
    public static float BansheeDamagePer = 0.4f;
    public static float BansheeHitPointPer = 0.4f;
    public static float BansheeSpeedPer = 0.1f;
    // Harpy
    public static float HappyRange = 3f;
    public static float HappyBaseHitPoints = 20f;
    public static float HarpySelectedRange = 1.5f;
    public static float HarpyDamage = 5f;
    public static float HarpyDamagePer = 0.5f;
    public static float HarpyHitpointsPer = 0.5f;
    public static float HarpySpeedPer = 0.1f;


    // Monitor
    public static float MonitorRange = 3f;
    public static float MonitorBaseHitPoints = 40f;
    public static float MonitorSelectedRange = 1.5f;
    public static float MonitorDamage = 4f;
    public static float MonitorDamagePer = 0.3f;
    public static float MonitorHitPointPer = 0.7f;
    public static float MonitorSpeedPer = 0.1f;

    // Orge
    public static float OgreRange = 3f;
    public static float OgreBaseHitPoints = 25f;
    public static float OgreSelectedRange = 1.5f;
    public static float OgreDamage = 7f;
    public static float OgreDamagePer = 0.4f;
    public static float OgreHitPointPer = 0.6f;
    public static float OgreSpeedPer = 0.1f;

    // Ghost
    public static float GhostRange = 3f;
    public static float GhostBaseHitPoints = 25f;
    public static float GhostSelectedRange = 1.5f;
    public static float GhostDamage = 7f;
    public static float GhostDamagePer = 0.4f;
    public static float GhostHitPointPer = 0.6f;
    public static float GhostSpeedPer = 0.1f;

    // Tower
    public static float AOETowerDamage = 3f;
    public static float AOETowerCoolDown = 1f;
    public static float AOETowerDamagePerLevel = 1f;



    public static float ArcheryTowerDamage = 2f;
    public static float ArcheryTowerCoolDown = 0.5f;
    public static float ArcheryTowerDamagePerLevel = 0.5f;


    public static float MageTowerDamage = 4f;
    public static float MageTowerCoolDown = 1.25f;
    public static float MageTowerDamagePerLevel = 1.25f;







    public static void Reset()
    {
       // Gold.TotalGold = 100;

        ArcheryDamage = 7f;
        ArcheryHitPoint = 40;
        ArcherySpeed = 5f;
        ArcheryStrength = (ArcheryDamage + ArcheryHitPoint / 2) + (1 + ArcherySpeed / 3);
        WarriorDamage = 7f;
        WarriorHitPoint = 50f;
        WarriorSpeed = 5f;

        WarriorStrength = (WarriorDamage + WarriorHitPoint / 2) + (1 + WarriorSpeed / 3);
    }
}