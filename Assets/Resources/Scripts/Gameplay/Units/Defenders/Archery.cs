using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class Archery : Defender
{


    public Animator animator;
    public Archery(int level) : base(level)
    {
    }

    // Start is called before the first frame update
    void Start()
    {

        //Instantiate<GameObject>(atkShape, transform.position, Quaternion.identity);
        AttackRange = ManageInfor.ArcheryRange;
        SelectedRange = ManageInfor.ArcheryRelectedRange;

        Level = ManageInfor.ArcheryLevel;
        CoolDown = 1;
        BaseDamage = ManageInfor.ArcheryDefautDamage;
        BaseHitPoints = ManageInfor.ArcheryDefautHitpoint;
        BaseSpeed = 15;
        //Damage = BaseDamage * damagePer * Level;



        Initialize(ManageInfor.ArcheryDamagePer, ManageInfor.ArcheryHitpointsPer, 1);


        // Đặt boxCollider1 là Trigger
        //MOVE = 1,
        //ATTACK = 2,
        //IDLE = 0
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
              //  Debug.Log("updateAtack----:" + stateAttack);
                break;
            case 0:
                animator.SetInteger("stateAttack", 0);
               // Debug.Log("updateAtack----:" + stateAttack);
                break;
        }
    }
}
