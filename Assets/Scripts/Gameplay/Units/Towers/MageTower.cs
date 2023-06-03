namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class MageTower : Tower
    {
        private void Start()
        {
            Damage = ConfigurationUtils.MageTowerDamage;
            Cooldown = ConfigurationUtils.MageTowerCoolDown;
        }
    }
}
