using Assets.Resources.Scripts.Gameplay.Units.Towers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public abstract class Tower : MonoBehaviour
    {
        Quaternion targetRotation;

        [SerializeField]
        GameObject bullet;
        public Animator animator;
        Timer cooldownTimerBullet;
        private bool finishedRotate = false;
        public static List<GameObject> colliders = new List<GameObject>();

        public bool isAttack;
        private double damage;
        private double cooldown;
        private double range;

        public double Damage { get => damage; set => damage = value; }
        public double Cooldown { get => cooldown; set => cooldown = value; }
        public double Range { get => range; set => range = value; }

        private void Awake()
        {
            cooldownTimerBullet = gameObject.AddComponent<Timer>();
        }

        protected void Initialize()
        {

            var range = gameObject.AddComponent<CircleCollider2D>();
            range.radius = (float)Range;
            range.isTrigger = true;
            //cooldownTimerBullet = gameObject.AddComponent<Timer>();

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            GameObject monster = collision.gameObject;
            // if selected monster is in range, attack it
            if (MonsterTargetClickManager.SelectedMonster != null && MonsterTargetClickManager.SelectedMonster == monster)
            {
                AttackSelectedMonster(collision);
                //Debug.Log("Attack target monster");
            }
            // else, follow original behaviors
            else
            {
               // Debug.Log("Attack others monster");

                if (TowerModeAttackManager.Mode == 1)
                    AttackMonsterWithLowestHitPoint(collision);
                else
                {
                    AttackClosestMonster(collision);
                }
            }
        }

        void AttackSelectedMonster(Collider2D collision)
        {

            GameObject targetAttacker = collision.gameObject;

            // If the target attacker is not null then rotate the gun to target direction and attack
            if (targetAttacker != null)
            {
                float angle = Mathf.Atan2(targetAttacker.transform.position.y - transform.position.y, targetAttacker.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
                targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                float angleDiff = Quaternion.Angle(transform.rotation, targetRotation);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10);

                if (angleDiff <= 1)
                {
                    finishedRotate = true;
                }
                else
                {
                    finishedRotate = false;
                }

                // If cooldown is already and the gun is rotate successfully to the direction of the target then shoot
                if (!cooldownTimerBullet.Running && finishedRotate)
                {
                    isAttack = true;
                    cooldownTimerBullet.Duration = 1;
                    cooldownTimerBullet.Run();
                    GameObject createdBullet = Instantiate(bullet, transform.position, transform.rotation);
                    createdBullet.transform.rotation = targetRotation;
                    createdBullet.GetComponent<TowerAttack>().Damage = (float)Damage;
                    createdBullet.GetComponent<TowerAttack>().sourceGameObject = gameObject;
                    createdBullet.GetComponent<TowerAttack>().targetDirection = targetAttacker.transform.position;
                    createdBullet.GetComponent<TowerAttack>().targetGameObject = targetAttacker.GetComponent<Unit>();
                    createdBullet.GetComponent<TowerAttack>().targetGameObjectPrefab = targetAttacker;
                    createdBullet.GetComponent<Rigidbody2D>().AddForce((targetAttacker.transform.position - transform.position).normalized * 15f, ForceMode2D.Impulse);
                    AudioManager.Play(AudioClipName.BurgerShot);
                }
            }

        }


        void AttackMonsterWithLowestHitPoint(Collider2D collision)
        {
            // Check if the target is attackers then trigger attack otherwise do nothing
            if (collision.gameObject.CompareTag("attackers"))
            {
                // Each attacker has two colliders, one for trigger to world physics, and one to demonstrate their attack range
                // Check if the collider is the first collider then continue logic
                if (collision.gameObject.GetComponents<CircleCollider2D>()[0] == collision)
                {
                    float minHitPoints = float.MaxValue;
                    GameObject weakestAttacker = null;

                    // Add colliders to list 
                    if (!colliders.Contains(collision.gameObject) && collision.CompareTag("attackers"))
                    {
                        colliders.Add(collision.gameObject);
                    }

                    // Loop through each collider to find the attacker with the lowest hitpoints
                    foreach (GameObject collider in colliders)
                    {
                        if (collider.gameObject != null && collider.CompareTag("attackers"))
                        {
                            float hitPoints = collider.GetComponent<Attacker>().HitPoints;
                            if (hitPoints < minHitPoints)
                            {
                                minHitPoints = hitPoints;
                                weakestAttacker = collider;
                            }
                        }
                    }

                    // If the weakest attacker is not null then rotate the gun to target direction
                    if (weakestAttacker != null)
                    {
                        float angle = Mathf.Atan2(weakestAttacker.transform.position.y - transform.position.y, weakestAttacker.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
                        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                        float angleDiff = Quaternion.Angle(transform.rotation, targetRotation);

                        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10);

                        if (angleDiff <= 1)
                        {
                            finishedRotate = true;
                        }
                        else
                        {
                            finishedRotate = false;
                        }

                        // If cooldown is already and the gun is rotate successfully to the direction of the target then shoot
                        if (!cooldownTimerBullet.Running && finishedRotate)
                        {
                            isAttack = true;
                            cooldownTimerBullet.Duration = 1;
                            cooldownTimerBullet.Run();
                            GameObject createdBullet = Instantiate(bullet, transform.position, transform.rotation);
                            createdBullet.transform.rotation = targetRotation;
                            createdBullet.GetComponent<TowerAttack>().Damage = (float)Damage;
                            createdBullet.GetComponent<TowerAttack>().sourceGameObject = gameObject;
                            createdBullet.GetComponent<TowerAttack>().targetDirection = weakestAttacker.transform.position;
                            createdBullet.GetComponent<TowerAttack>().targetGameObject = weakestAttacker.GetComponent<Unit>();
                            createdBullet.GetComponent<TowerAttack>().targetGameObjectPrefab = weakestAttacker;
                            createdBullet.GetComponent<Rigidbody2D>().AddForce((weakestAttacker.transform.position - transform.position).normalized * 15f, ForceMode2D.Impulse);
                            AudioManager.Play(AudioClipName.BurgerShot);
                        }
                    }
                }
            }
        }

        void AttackClosestMonster(Collider2D collision)
        {
            //check if the target is attackers then trigger attack otherwise do nothing
            if (collision.gameObject.CompareTag("attackers"))
            {
                //each attacker has two colliders, one for trigger to world physics, and one to demonstrate their attack range, check if the collider is the first collider then continue logic
                if (collision.gameObject.GetComponents<CircleCollider2D>()[0] == collision)
                {
                    //find the closest attackers
                    float minDistance = float.MaxValue;
                    GameObject closestCollider = null;
                    //add colliders to list 
                    if (!colliders.Contains(collision.gameObject) && collision.CompareTag("attackers"))
                    {
                        colliders.Add(collision.gameObject);
                    }
                    //loop through each collider to find the closest
                    foreach (GameObject collider in colliders)
                    {
                        if (collider.gameObject != null && collider.CompareTag("attackers"))
                        {
                            float distance = Vector2.Distance(collider.transform.position, gameObject.transform.position);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                closestCollider = collider;
                            }
                        }
                    }

                    //if the closest collider is not null then rotate the gun to target direction
                    if (closestCollider != null)
                    {
                        float angle = Mathf.Atan2(closestCollider.gameObject.transform.position.y - gameObject.transform.position.y, closestCollider.gameObject.transform.position.x - gameObject.transform.position.x) * Mathf.Rad2Deg;
                        targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                        float angleDiff = Quaternion.Angle(gameObject.transform.rotation, targetRotation);
                        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetRotation, 10);
                        if (angleDiff <= 1)
                        {
                            finishedRotate = true;
                        }
                        else
                        {
                            finishedRotate = false;
                        }

                        //if cooldown is already and the gun is rotate successfully to the direction of the target then shoot
                        if (!cooldownTimerBullet.Running && finishedRotate)
                        {
                            isAttack = true;
                            cooldownTimerBullet.Duration = 1;
                            cooldownTimerBullet.Run();
                            GameObject createdBullet = Instantiate(bullet, transform.position, transform.rotation);
                            createdBullet.transform.rotation = targetRotation;
                            createdBullet.GetComponent<TowerAttack>().Damage = (float)Damage;
                            createdBullet.GetComponent<TowerAttack>().sourceGameObject = gameObject;
                            createdBullet.GetComponent<TowerAttack>().targetDirection = closestCollider.gameObject.transform.position;
                            createdBullet.GetComponent<TowerAttack>().targetGameObject = closestCollider.gameObject.GetComponent<Unit>();
                            createdBullet.GetComponent<TowerAttack>().targetGameObjectPrefab = closestCollider.gameObject;
                            createdBullet.GetComponent<Rigidbody2D>().AddForce((closestCollider.gameObject.transform.position - gameObject.transform.position).normalized * 15f, ForceMode2D.Impulse);
                            AudioManager.Play(AudioClipName.BurgerShot);
                        }

                    }

                }
            }
        }

        //if target is outside
        void OnTriggerExit2D(Collider2D other)
        {
            isAttack = false;
        }

        public abstract void Create(Vector2 buildPosition, GameObject gameObject);


    }
}
