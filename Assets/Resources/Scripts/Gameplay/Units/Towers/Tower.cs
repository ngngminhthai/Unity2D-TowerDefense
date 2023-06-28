﻿using System.Collections.Generic;
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
            if (collision.gameObject.CompareTag("attackers"))
            {
                if (collision.gameObject.GetComponents<CircleCollider2D>()[1] == collision)
                {
                    float minDistance = float.MaxValue;
                    GameObject closestCollider = null;
                    if (!colliders.Contains(collision.gameObject) && collision.CompareTag("attackers"))
                    {
                        colliders.Add(collision.gameObject);
                    }
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
                            //Debug.Log("Shoot");
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
        void OnTriggerExit2D(Collider2D other)
        {
            isAttack = false;
        }

        public abstract void Create(Vector2 buildPosition, GameObject gameObject);


    }
}