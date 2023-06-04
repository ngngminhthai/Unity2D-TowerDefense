using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Attacker
{
   

    
    public Animator animator;
    public int level;
    public Ogre(int level) : base(level)
    {
    }
    
    public void Start()
    {
        unityEvents.Add(EventName.GoldChangeEvent, new GoldChangeEvent());
        EventManager.AddInvoker(EventName.GoldChangeEvent, this);
        Initialize();
    }

    private void Initialize()
    {
        AttackRange = ManageInfor.OgreRange;
        SelectedRange = ManageInfor.OgreSelectedRange;
        if (level == null)
        {
            Level = 0;
        }
        else
        {
            Level = level;
        }


        CoolDown = 1;
        BaseDamage = ManageInfor.OgreDamage;
        BaseHitPoints = ManageInfor.OgreBaseHitPoints;
        BaseSpeed = 10;

        Initialize(ManageInfor.OgreDamagePer, ManageInfor.OgreHitPointPer, 0.1f);
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


        unityEvents[EventName.GoldChangeEvent].Invoke(1);
        base.Die();
        // Gold.PlusGold(value);



    }

}
