namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class AOETower : Tower
    {
        void Start()
        {

            Damage = ConfigurationUtils.AOETowerDamage;
            Cooldown = ConfigurationUtils.AOETowerCoolDown;
            Range = ConfigurationUtils.AOETowerRange;

            Initialize();

        }
    }
}
