using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Towers
{
    public class AOETowerAttack : TowerAttack
    {
        public float areaOfEffectRadius = 5f;
        public int wireSphereDrawOrder = 50; // Specify the order in the layer hierarchy

        [SerializeField]
        public GameObject rangeAnimation;


        public override void DoesEffectBehaviour()
        {
            base.DoesEffectBehaviour();

            // Get all the colliders within the area of effect radius
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, areaOfEffectRadius);

            foreach (Collider2D collider in colliders)
            {
                // Check if the collider belongs to an enemy unit
                Unit unit = collider.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.TakeDamage(Damage);
                    var animation = GameObject.Instantiate(rangeAnimation, gameObject.transform.position, Quaternion.identity);
                    //Tower.colliders.Remove(collider.gameObject);
                    //OnDrawGizmosSelected();
                }
            }
        }


    }

}
