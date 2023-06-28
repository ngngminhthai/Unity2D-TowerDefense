using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class Warrion : Defender
{
    // Start is called before the first frame update
    public Animator animator;
    public Warrion(int level) : base(level)
    {
    }

    void Start()
    {
        //Instantiate<GameObject>(atkShape, transform.position, Quaternion.identity);
        AttackRange = ManageInfor.WarriorRange;
        SelectedRange = ManageInfor.WarriorSelectedRange;

        Level = ManageInfor.WarriorLevel;
        CoolDown = 1;
        /* BaseDamage = ManageInfor.WarriorDefautDamage;
         BaseHitPoints = ManageInfor.WarriorHitPoint;*/

        BaseDamage = ManageInfor.WarriorDamage;
        BaseHitPoints = ManageInfor.WarriorHitPoint;

        BaseSpeed = ManageInfor.WarriorSpeed;
        //Damage = BaseDamage * damagePer * Level;


        Initialize(ManageInfor.ArcheryDamagePer, ManageInfor.WarriorHitpointsPer, 1);
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
