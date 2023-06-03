namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class ArcheryTower : Tower
    {
        private void Start()
        {
            Damage = ConfigurationUtils.ArcheryTowerDamage;
            Cooldown = ConfigurationUtils.ArcheryTowerCoolDown;
        }
    }
}
