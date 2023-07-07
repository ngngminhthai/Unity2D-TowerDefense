using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Attacker : Unit
    {
        private Defender currentTarget;


        public Attacker(int level) : base(level)
        {
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            //check if towwer
            if (other.CompareTag("tower"))
            {
                HeadQuarter enemy = other.GetComponent<HeadQuarter>();
                Attack(enemy);
                isAttack = true;
            }
            // Check if the collider belongs to a Defender unit
            if (currentTarget != null && currentTarget.tag == "defenders")
            {
                // Debug.Log("Ok");
                AgentMoventMentMonster agent = gameObject.GetComponent<AgentMoventMentMonster>();
                //    Debug.Log(HitPoints + "end2");
                // trien khai cach 1 : target luon la currentTarget ( Cham thang nao thi duoi theo danh cho chet bang dc )
                if (HitPoints > 0f)
                {
                    agent.SetTargetPosition(currentTarget.gameObject);
                    float threshold = 0.1f;
                    Vector3 FlipDirection = currentTarget.transform.position - transform.position;
                    float dotProduct = Vector3.Dot(FlipDirection, transform.right);
                    if (dotProduct < -threshold)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if (dotProduct > threshold)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
                // trien khai cach 2 : trong combat cham thang nao thi danh thang do
                //agent.SetTargetPosition(other.gameObject);
                //currentTarget = other.gameObject.GetComponent<Defender>();
                agent.isAccessMovingTower = false;
                // Đủ tầm đánh mới Stop 
                if (Vector2.Distance(transform.position, currentTarget.transform.position) <= attackRange)
                {
                    // Debug.Log(HitPoints + "abcde");
                    // Debug.Log("Da Dung");
                    if (HitPoints > 0f)
                    {
                        agent.StopMoving();
                    }
                }
            }
            else
            {
                // Đánh chết defenders thì đi tiếp đến trụ 
                AgentMoventMentMonster agent = gameObject.GetComponent<AgentMoventMentMonster>();
                agent.isAccessMovingTower = true;
                // Animation xoay hướng đến trụ
                if (HitPoints > 0f)
                {
                    float threshold = 0.1f;
                    if (agent.tower != null)
                    {
                        Vector3 FlipDirection = agent.tower.transform.position - transform.position;
                        float dotProduct = Vector3.Dot(FlipDirection, transform.right);
                        if (dotProduct < -threshold)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                        }
                        else if (dotProduct > threshold)
                        {
                            transform.localScale = new Vector3(1, 1, 1);
                        }
                    }
                    //  Debug.Log(HitPoints + "end + " + isAttack);
                    isAttack = false;
                    // Debug.Log(HitPoints + "end + " + isAttack);
                    agent.ContinueMoving();
                }
            }
            // Check if the collider belongs to a Defender unit
            Defender defender = other.GetComponent<Defender>();
            if (other.GetComponent<Defender>() is Defender)
                if (defender != null && (currentTarget == null || defender == currentTarget))
                {
                    // Attack the Defender
                    currentTarget = defender;
                    Attack(defender);
                }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // Check if the collider belonged to the current target
            Defender defender = other.GetComponent<Defender>();
            if (other.GetComponent<Defender>() is Defender)
            {
                if (defender != null && defender == currentTarget)
                {
                    // Stop attacking the current target
                    //  Debug.Log("Out");
                    // Debug.Log(HitPoints);
                    // Neu Defender move khoi Attracker thi set lai target den vi tri Defender vua move
                    AgentMoventMentMonster agent = gameObject.GetComponent<AgentMoventMentMonster>();
                    if (HitPoints > 0f)
                    {
                        //  Debug.Log(HitPoints + "acddddd");
                        agent.SetTargetPosition(currentTarget.gameObject);
                        agent.ContinueMoving();
                        isAttack = false;
                    }
                    agent.isAccessMovingTower = false;
                    currentTarget = null;
                }
            }
        }

        public override void Attack(Unit target)
        {
            // Only attack Defender units
            Defender defender = target as Defender;
            if (defender != null)
            {
                //Debug.Log(target);
                base.Attack(target);
            }
            HeadQuarter tower = target as HeadQuarter;
            if (tower != null)
            {
                base.Attack(tower);
            }
        }

        protected override void Die()
        {
            isAttack = false;
            // If the current target dies, stop attacking it
            if (currentTarget != null && currentTarget.HitPoints <= 0f)
            {
                currentTarget = null;
            }
            AudioManager.Play(AudioClipName.BurgerDeath);
            base.Die();
            // Gold.PlusGold(value);
        }

        public int GainedGold { get; set; }

        public float Strength2()
        {
            float Strength = (MaxHitPoint / 2 + Damage) + (1 + Speed / 3);
            return Strength;
        }

    }
}
