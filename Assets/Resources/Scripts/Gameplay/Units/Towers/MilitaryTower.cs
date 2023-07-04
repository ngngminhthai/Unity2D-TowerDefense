using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Towers
{
    public class MilitaryTower : NonAttackTower
    {
        Timer timer;

        [SerializeField]
        GameObject warrionUnit;

        private float summonCooldown = 4.0f;
        private int summonedUnits = 0;
        private int maxUnits = 3;


        //This method is used for tower factory to spawn new tower
        public override void Create(Vector2 buildPosition, GameObject gameObject)
        {
            GameObject spaw = Instantiate<GameObject>(gameObject, buildPosition, Quaternion.identity);
        }

        private void Start()
        {
            timer = gameObject.AddComponent<Timer>();
            timer.Duration = summonCooldown;
            timer.Run();
        }

        private void Update()
        {
            if (timer.Finished)
            {
                SummonDefenders();
                timer.Duration = summonCooldown;
                timer.Run();
            }
        }

        public void SummonDefenders()
        {
            if (summonedUnits < maxUnits)
            {
                Instantiate(warrionUnit, transform.position, Quaternion.identity);
                summonedUnits++;
            }
        }
    }
}
