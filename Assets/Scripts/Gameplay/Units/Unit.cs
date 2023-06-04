using Assets.Scripts.Common;
using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public abstract class Unit : IntEventInvoker
{
    private int level = 1;

    private float damage;
    private float hitPoints;
    private float maxHitPoints;
    private float speed;
    protected float attackRange;
    private float selectedRange;
    private AttackType attackType;
    private float coolDown;
    protected Timer cooldownTimerBullet;


    private float baseDamage;
    private float baseHitPoints;
    private float baseSpeed;

    public CircleCollider2D atkRangeCollider;
    public CircleCollider2D selectedRangeCollider;

    [SerializeField]
    protected GameObject AttackShape;

    public Unit(int level)
    {
        this.Level = level;
    }

    public float Damage { get => damage; set => damage = value; }
    public float HitPoints { get => hitPoints; set => hitPoints = value; }
    public float Speed { get => speed; set => speed = value; }

    public float BaseDamage { get => baseDamage; set => baseDamage = value; }
    public float BaseHitPoints { get => baseHitPoints; set => baseHitPoints = value; }
    public float BaseSpeed { get => baseSpeed; set => baseSpeed = value; }
    public float AttackRange { get => attackRange; set => attackRange = value; }
    public float CoolDown { get => coolDown; set => coolDown = value; }
    public AttackType AttackType { get => attackType; set => attackType = value; }
    public float SelectedRange { get => selectedRange; set => selectedRange = value; }
    public int Level { get => level; set => level = value; }
    public float MaxHitPoint { get => maxHitPoints; set => maxHitPoints = value; }


    public bool isAttack = false;
    public int stateAttack;

    public HealthBar healthBar;
    public void Awake()
    {
        
        unityEvents.Add(EventName.GoldChangeEvent, new GoldChangeEvent());
        EventManager.AddInvoker(EventName.GoldChangeEvent, this);
    }

    public virtual void Initialize(float damageMultiplier, float hitpointMultiplier, float speedMultiplier)
    {
        Damage = BaseDamage + BaseDamage * damageMultiplier * Level;
        HitPoints = BaseHitPoints + baseHitPoints * hitpointMultiplier * Level;
        Speed = BaseSpeed * speedMultiplier * Level;

        cooldownTimerBullet = gameObject.AddComponent<Timer>();

        selectedRangeCollider = gameObject.AddComponent<CircleCollider2D>();
        atkRangeCollider = gameObject.AddComponent<CircleCollider2D>();

        atkRangeCollider.radius = AttackRange;
        selectedRangeCollider.radius = SelectedRange;

        atkRangeCollider.isTrigger = true;
        selectedRangeCollider.isTrigger = false;
        MaxHitPoint = HitPoints;
        // M?i thêm v? HealthBar
        healthBar.SetMaxHealth(HitPoints);
    }

    
    public virtual void Attack(Unit target)
    {
        // Tranh bao loi vi attracker khong co script AgentMoventMent
        if (gameObject.GetComponent<AgentMoventMent>() != null)
        {
            if (gameObject.GetComponent<AgentMoventMent>().CheckIsMoving())
            {
                return;
            }
        }
        //if unit are not in attacking state
        if (!cooldownTimerBullet.Running)
        {
            //Debug.Log("Shoot");
            cooldownTimerBullet.Duration = 1;
            cooldownTimerBullet.Run();
            DisplayAttackShape(target.transform.position, target);
        }
        isAttack = true;
        stateAttack = (int)STATE_ATTACK.ATTACK;
    }
    public virtual void DisplayAttackShape(Vector2 direction, Unit target)
    {

        Vector2 directionTarget = direction - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(directionTarget.y, directionTarget.x) * Mathf.Rad2Deg;


        if (AttackShape.GetComponent<MeleAttack>() is MeleAttack)
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), direction) <= AttackRange)
            {
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                //Debug.Log("AttackShape is a MeleAttack");
                var atkShape = GameObject.Instantiate(AttackShape, direction, Quaternion.identity);
                atkShape.transform.rotation = rotation;
                target.TakeDamage(Damage);
            }
        }
        if (AttackShape.GetComponent<AOEAttack>() is AOEAttack)
        {

            Instantiate(AttackShape, transform.position, Quaternion.identity);



        }

        else if (AttackShape.GetComponent<RangedAttack>() is RangedAttack)
        {
            //Debug.Log("AttackShape is a Ranged");
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            //Behaviour of Ranged class write here
            //For eg
            //radius = gameobj.getComponent<CircleCollider2D>().radius
            //shoot from the current game object position
            var atkShape = GameObject.Instantiate(AttackShape, gameObject.transform.position, Quaternion.identity);
            //var radius = 10; // get circle collider here
            var rangedAttack = atkShape.GetComponent<RangedAttack>();
            if (rangedAttack != null)
            {

                //get radius of "attack range" collider
                //rangedAttack.Range = GetComponents<CircleCollider2D>()[1].radius;
                rangedAttack.Range = atkRangeCollider.radius;
            }
            Rigidbody2D rb2d = atkShape.GetComponent<Rigidbody2D>();
            rangedAttack.sourceDirection = transform.position;
            rangedAttack.targetDirection = direction;
            rangedAttack.Damage = 5;
            //them target cho attack range 
            rangedAttack.targetGameObject = target;

            rb2d.AddForce(directionTarget.normalized * 3, ForceMode2D.Impulse);
            atkShape.transform.rotation = rotation;

        }


    }

    public virtual void TakeDamage(float amount)
    {
        HitPoints -= amount;
        healthBar.SetHealth(HitPoints);
        if (HitPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        /* Attacker attacker = GetComponent<Attacker>();
         if (attacker != null)
         {
             // Broadcast event to all Defender objects
             Defender[] defenders = FindObjectsOfType<Defender>();
             foreach (Defender defender in defenders)
             {
                 defender.ContinueMoving();
             }
         }*/
        // Destroy the game object
        Destroy(gameObject);
    }

    public virtual void LevelUp()
    {
        Level++;
    }

    public static float Strength;
    public virtual float StrengtCaculation()
    {
        Strength = (damage + HitPoints / 2) + (1 + speed / 3);
        return Strength;

    }


}

