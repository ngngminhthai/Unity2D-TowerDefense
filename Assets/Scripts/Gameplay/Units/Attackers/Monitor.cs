using Assets.Scripts.Gameplay.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : Attacker
{
    // Start is called before the first frame update


 
    public Animator animator;
    public int level;
    public Monitor(int level) : base(level)
    {
        animator.SetBool("isAttack", false);
    }

    public void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        AttackRange = ManageInfor.MonitorRange;
        SelectedRange = ManageInfor.MonitorSelectedRange;
        if (level == null)
        {
            Level = 0;
        }
        else
        {
            Level = level;
        }


        CoolDown = 2;
        BaseDamage = ManageInfor.MonitorDamage;
        BaseHitPoints = ManageInfor.MonitorBaseHitPoints;
        BaseSpeed = 15;

        Initialize(ManageInfor.MonitorDamagePer, ManageInfor.MonitorHitPointPer, 0.1f);
        OnLanding();
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
    public void OnLanding()
    {
        animator.SetBool("isAttack", false);
    }
   
}
