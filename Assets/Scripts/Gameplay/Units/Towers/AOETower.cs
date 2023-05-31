namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class AOETower : Tower
    {
        void Start()
        {

            Damage = ConfigurationUtils.AOETowerDamage;
            Cooldown = ManageInfor.AOETowerCoolDown;

            InitializeTimer();

        }
    }
}
