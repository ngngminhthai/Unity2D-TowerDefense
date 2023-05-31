using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Defenders
{
    public class Tower : MonoBehaviour
    {
        Quaternion targetRotation;

        [SerializeField]
        GameObject bullet;

        Timer cooldownTimerBullet;
        private bool finishedRotate = false;
        public static List<GameObject> colliders = new List<GameObject>();


        private double damage;
        private double cooldown;

        public double Damage { get => damage; set => damage = value; }
        public double Cooldown { get => cooldown; set => cooldown = value; }


        void Start()
        {

        }

        protected void InitializeTimer()
        {
            cooldownTimerBullet = gameObject.AddComponent<Timer>();
        }

        // Update is called once per frame
        void Update()
        {
        }


        public virtual void Initialize(float damageMultiplier)
        {

        }


        private void OnTriggerStay2D(Collider2D collision)
        {
            float minDistance = float.MaxValue;
            GameObject closestCollider = null;
            if (!colliders.Contains(collision.gameObject) && collision.CompareTag("Circle"))
            {
                colliders.Add(collision.gameObject);
            }
            foreach (GameObject collider in colliders)
            {
                if (collider.CompareTag("Circle"))
                {
                    float distance = Vector2.Distance(collider.transform.position, gameObject.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestCollider = collider;
                    }
                }
            }

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

                if (!cooldownTimerBullet.Running && finishedRotate)
                {
                    Debug.Log("Shoot");
                    cooldownTimerBullet.Duration = 1;
                    cooldownTimerBullet.Run();
                    GameObject createdBullet = Instantiate(bullet, transform.position, transform.rotation);
                    createdBullet.transform.rotation = targetRotation;
                    createdBullet.GetComponent<Rigidbody2D>().AddForce((closestCollider.gameObject.transform.position - gameObject.transform.position).normalized * 15f, ForceMode2D.Impulse);
                }
            }
        }

    }
}
