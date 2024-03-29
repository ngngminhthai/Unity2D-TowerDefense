﻿using Assets.Scripts.Gameplay.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Gameplay.Units.Attackers
{
    public class Boss : Attacker
    {
        public Animator animator;
        public int level;
        public Boss(int level) : base(level)
        {
        }

        public void Start()
        {
            unityEvents = new Dictionary<EventName, UnityEngine.Events.UnityEvent<int>>();
            unityEvents.Add(EventName.GoldChangeEvent, new GoldChangeEvent());
            EventManager.AddInvoker(EventName.GoldChangeEvent, this);
            Initialize();
        }

        private void Initialize()
        {
            AttackRange = ManageInfor.BossRange;
            SelectedRange = ManageInfor.BossSelectedRange;
            if (level == null)
            {
                Level = 0;
            }
            else
            {
                Level = level;
            }


            CoolDown = 1;
            BaseDamage = ManageInfor.BossDamage;
            BaseHitPoints = ManageInfor.BossBaseHitPoints;
            BaseSpeed = 10;

            Initialize(ManageInfor.BossDamagePer, ManageInfor.BossHitPointPer, 0.1f);
            //animator.SetBool("isAttack", false);
        }
        public void Update()
        {
            if (isAttack)
            {
                animator.SetBool("isAttack", true);
                //Debug.Log("True"); 
            }
            else
            {
                animator.SetBool("isAttack", false);
                //Debug.Log("flase");

            }
        }
        protected override void Die()
        {

            int value = Convert.ToInt32(Math.Ceiling(Strength2()));
            unityEvents[EventName.GoldChangeEvent].Invoke(value);
            base.Die();
            // Gold.PlusGold(value);



        }
    }
}
