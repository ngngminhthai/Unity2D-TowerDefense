using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class AOETower : Tower
    {
        //public Animator animator;
        [SerializeField]
        int currentLevel;

        

        public override void Create(Vector2 buildPosition, GameObject gameObject)
        {
            GameObject spaw = Instantiate<GameObject>(gameObject, buildPosition, Quaternion.identity);
        }


        void Start()
        {
            animator.SetBool("isAttack", false);
            isAttack = false;
            if (currentLevel == 1)
            {
                Damage = ConfigurationUtils.AOETowerDamage;
                Cooldown = ConfigurationUtils.AOETowerCoolDown;
                Range = ConfigurationUtils.AOETowerRange;
            }
            else if (currentLevel == 2)
            {
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
            //animator.SetBool("isAttack", false);
            Initialize();
        }
        public void Update()
        {

            if (isAttack)
            {
                animator.SetBool("isAttack", true);
            }
            else
            {
                animator.SetBool("isAttack", false);
            }
        }
    }
}
