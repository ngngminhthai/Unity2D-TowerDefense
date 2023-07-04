using Assets.Scripts.Gameplay.Units.Defenders;
using System;

namespace Assets.Scripts.Gameplay.Units.Towers
{
    public class TowerFactory
    {
        public Tower GetTower(string TowerType)
        {
            switch (TowerType)
            {
                case "Archery":
                    return new ArcheryTower();
                case "Mage":
                    return new MageTower();
                case "AOE":
                    return new AOETower();
                default:
                    throw new ArgumentException("Invalid tower type");
            }
        }

        public NonAttackTower GetNonAttackTower(string TowerType)
        {
            switch (TowerType)
            {
                case "Milatary":
                    return new MilitaryTower();
                default:
                    throw new ArgumentException("Invalid tower type");
            }
        }
    }
}
