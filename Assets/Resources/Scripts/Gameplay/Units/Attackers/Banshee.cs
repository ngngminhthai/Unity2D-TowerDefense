using Assets.Scripts.Gameplay.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banshee : Attacker
{
    public Banshee(int level) : base(level)
    {
    }

    Timer TimerObject;
    public Animator animator;
    public int level;

    [SerializeField]
    GameObject bullet;

    // Start is called before the first frame update
    public void Start()
    {
        unityEvents = new Dictionary<EventName, UnityEngine.Events.UnityEvent<int>>();
        unityEvents.Add(EventName.GoldChangeEvent, new GoldChangeEvent());
        EventManager.AddInvoker(EventName.GoldChangeEvent, this);
        AttackRange = ManageInfor.BansheeRange;
        SelectedRange = ManageInfor.BansheeSelectedRange;
       // Debug.Log("Banshee: " + AttackRange);
        if ( level == null)
        {
            Level = 0;
        }
        else
        {
            Level = level;
        }
      
        CoolDown = 1;
        BaseDamage = ManageInfor.BansheeDamage;
        BaseHitPoints = ManageInfor.BansheeBaseHitPoints;
        BaseSpeed = 15;
        //Damage = BaseDamage * damagePer * Level;


        Initialize(ManageInfor.BansheeDamagePer, ManageInfor.BansheeHitPointPer, 0.1f);

        TimerObject = gameObject.AddComponent<Timer>();
        TimerObject.Duration = 5;
        TimerObject.Run();
    }

    // Update is called once per frame
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
        if (TimerObject.Finished)
        {
            AttackSkillDefender();
            TimerObject.Duration = 5;
            TimerObject.Run();
        }
    }
    protected override void Die()
    {

        int value = Convert.ToInt32(Math.Ceiling(Strength2()));
        unityEvents[EventName.GoldChangeEvent].Invoke(value);
        base.Die();
        // Gold.PlusGold(value);
    }
    void AttackSkillDefender()
    {
        GameObject[] defenders = GameObject.FindGameObjectsWithTag("defenders");

        GameObject nearestDefender = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject defender in defenders)
        {
            float distance = Vector3.Distance(transform.position, defender.transform.position);

            if (distance <= 100f && distance < nearestDistance)
            {
                nearestDefender = defender;
                nearestDistance = distance;
            }
        }

        if (nearestDefender != null)
        {
            //Vector2 direction = nearestDefender.transform.position;
            //Vector2 directionTarget = direction - new Vector2(transform.position.x, transform.position.y);
            //float angle = Mathf.Atan2(directionTarget.y, directionTarget.x) * Mathf.Rad2Deg;
            //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //var atkBullet = GameObject.Instantiate(bullet, direction, Quaternion.identity);
            //atkBullet.transform.rotation = rotation;
            //atkBullet.GetComponent<Rigidbody2D>().AddForce((nearestDefender.transform.position - transform.position).normalized * 15f, ForceMode2D.Impulse);
            //AudioManager.Play(AudioClipName.BurgerShot);

            Vector2 direction = nearestDefender.transform.position;
            Vector2 directionTarget = direction - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(directionTarget.y, directionTarget.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            var atkBullet = GameObject.Instantiate(bullet, transform.position, rotation);
            atkBullet.GetComponent<Rigidbody2D>().AddForce(directionTarget.normalized * 15f, ForceMode2D.Impulse);
            AudioManager.Play(AudioClipName.BurgerShot);
        }
    }
}

