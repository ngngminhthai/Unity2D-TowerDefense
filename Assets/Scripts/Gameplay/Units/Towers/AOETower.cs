using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class AOETower : Tower
    {
        public override void Create(Vector2 buildPosition, GameObject gameObject)
        {
            GameObject spaw = Instantiate<GameObject>(gameObject, buildPosition, Quaternion.identity);
        }

        void Start()
        {

            Damage = ConfigurationUtils.AOETowerDamage;
            Cooldown = ConfigurationUtils.AOETowerCoolDown;
            Range = ConfigurationUtils.AOETowerRange;

            Initialize();

        }
    }
}
