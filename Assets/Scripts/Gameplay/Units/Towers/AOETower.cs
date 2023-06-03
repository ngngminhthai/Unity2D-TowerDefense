using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class AOETower : Tower
    {
        [SerializeField]
        int currentLevel; 

        public override void Create(Vector2 buildPosition, GameObject gameObject)
        {
            GameObject spaw = Instantiate<GameObject>(gameObject, buildPosition, Quaternion.identity);
        }

        void Start()
        {
            if (currentLevel == 1){
                Damage = ConfigurationUtils.AOETowerDamage;
                Cooldown = ConfigurationUtils.AOETowerCoolDown;
                Range = ConfigurationUtils.AOETowerRange;
            }else if (currentLevel == 2){
                Damage = ConfigurationUtils.AOETowerDamage + 1; 
                Cooldown = ConfigurationUtils.AOETowerCoolDown;
                Range = ConfigurationUtils.AOETowerRange;
            }
            else
            {
                Damage = ConfigurationUtils.AOETowerDamage + 2;
                Cooldown = ConfigurationUtils.AOETowerCoolDown;
                Range = ConfigurationUtils.AOETowerRange; 
            }
            Initialize();
        }
    }
}
