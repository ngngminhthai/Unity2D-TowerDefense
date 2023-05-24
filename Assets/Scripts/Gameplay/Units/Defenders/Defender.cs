using UnityEngine;

namespace Assets.Scripts.Gameplay.Units
{
    public class Defender : Unit
    {

        public Attacker currentTarget;
        public Defender(int level) : base(level)
        {
        }

        public GameObject selection;


        private bool isInsideTrigger = false;

        // Khi một đối tượng khác vào bên trong collider



        public void ContinueMoving()
        {
            AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();
            if (HitPoints > 0f)
                agent.ContinueMoving();
        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.CompareTag("AoeAttack"))
        //    {
        //        TakeDamage(10f);
        //    }
        //}
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("attackers") && currentTarget == null)
            {

                AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();

                //currentTarget = other.GetComponent<Attacker>();
                agent.SetTargetWhenStaying(other.gameObject);
                currentTarget = other.GetComponent<Attacker>();
                return;
            }

            // Check if the collider belongs to a Defender unit

            if (currentTarget != null && currentTarget.tag == "attackers")
            {
                AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();

                if (GameClickManager.selectedTarget == gameObject)
                {
                    if(HitPoints > 0f)
                    agent.ContinueMoving();
                }
                else if (Vector2.Distance(transform.position, currentTarget.transform.position) <= attackRange)
                {
                    if (HitPoints > 0f)
                    {
                        agent.StopMoving();
                        stateAttack = 2;
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
                        //gameObject.GetComponent<AgentMoventMent>().isMoving = false;
                    }
                }
            }
            else
            {
                if (GameClickManager.selectedTarget == gameObject)
                {

                }
                else if (currentTarget == null && !other.gameObject.CompareTag("defenders") && !other.gameObject.CompareTag("tower"))
                {
                    AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();
                    stateAttack = 0;
                    agent.SetAgentPosition();
                }
                stateAttack = 0;
                /*
                                if (HitPoints > 0f)
                                    agent.ContinueMoving();*/
                // AgentMoventMent agent = gameObject.GetComponent<AgentMoventMent>();
                // stateAttack = 0;
                /* stateAttack = 0;
                 if (agent.isMoving == true)
                 {
                     agent.SetAgentPosition();
                 }*/


            }
            Attacker attacker = other.GetComponent<Attacker>();
            if (attacker != null && (currentTarget == null || attacker == currentTarget))
            {
                //currentTarget = attacker;
                // đến tầm mới bắn
                if (Vector2.Distance(transform.position, attacker.transform.position) <= attackRange)
                {
                    Attack(attacker);
                }
            }
        }

        public int UpGradedGold { get; set; }

        public float StrengthGold()
        {
            float Strength = (MaxHitPoint / 2 + Damage) + (1 + Speed / 3);
            return Strength;
        }

        protected override void Die()
        {
            float value = StrengthGold();
            Gold.PlusGold(value);
            Destroy(gameObject);
        }

    }
}
