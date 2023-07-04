using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class Xena : Defender
{
    // Start is called before the first frame update
    public Animator animator;
    public Xena(int level) : base(level)
    {
    }

    void Start()
    {
        //Instantiate<GameObject>(atkShape, transform.position, Quaternion.identity);
        AttackRange = ManageInfor.XenaRange;
        SelectedRange = ManageInfor.XenaSelectedRange;

        Level = ManageInfor.XenaLevel;
        CoolDown = 1;
        /* BaseDamage = ManageInfor.WarriorDefautDamage;
         BaseHitPoints = ManageInfor.WarriorHitPoint;*/

        BaseDamage = ManageInfor.XenaDamage;
        BaseHitPoints = ManageInfor.XenaHitPoint;

        BaseSpeed = ManageInfor.XenaSpeed;
        //Damage = BaseDamage * damagePer * Level;


        Initialize(ManageInfor.XenaDamagePer, ManageInfor.XenaHitpointsPer, 1);
    }
    public void Update()
    {

        switch (stateAttack)
        {
            case 1:
                animator.SetInteger("stateAttack", 1);
                break;
            case 2:
                animator.SetInteger("stateAttack", 2);

                break;
            case 0:
                animator.SetInteger("stateAttack", 0);

                break;
        }
    }
}
