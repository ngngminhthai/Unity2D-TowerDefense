using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class MageTower : Tower
    {
        [SerializeField]
        int currentLevel;

        public override void Create(Vector2 buildPosition, GameObject gameObject)
        {
            GameObject spaw = Instantiate<GameObject>(gameObject, buildPosition, Quaternion.identity);
        }

        private void Start()
        {
            if (currentLevel == 1)
            {
                Damage = ConfigurationUtils.MageTowerDamage;
                Cooldown = ConfigurationUtils.MageTowerCoolDown;
                Range = ConfigurationUtils.MageTowerRange;
            }
            else if (currentLevel == 2)
            {
                Damage = ConfigurationUtils.MageTowerDamage + 1;
                Cooldown = ConfigurationUtils.MageTowerCoolDown;
                Range = ConfigurationUtils.MageTowerRange;
            }
            else
            {
                Damage = ConfigurationUtils.MageTowerDamage + 2;
                Cooldown = ConfigurationUtils.MageTowerCoolDown;
                Range = ConfigurationUtils.MageTowerRange;
            }
            Initialize();
        }
    }
}
