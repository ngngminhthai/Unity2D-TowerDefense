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
                case "Archer":
                    return new ArcheryTower();
                case "Mage":
                    return new MageTower();
                case "AOE":
                    return new AOETower();
                default:
                    throw new ArgumentException("Invalid tower type");
            }
        }
    }
}
