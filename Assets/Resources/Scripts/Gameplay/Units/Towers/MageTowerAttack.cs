using UnityEngine;

namespace Assets.Scripts.Gameplay.Units.Towers
{
    public class MageTowerAttack : TowerAttack
    {
        [SerializeField]
        public GameObject posionPrefab;

        public AgentMoventMentMonster targetMonster; // Set this to the target monster 

        public override void DoesEffectBehaviour()
        {
            base.DoesEffectBehaviour();
            if (targetGameObjectPrefab != null)
            {
                AgentMoventMentMonster agent = targetGameObjectPrefab.GetComponent<AgentMoventMentMonster>();
                if (agent != null && !agent.isAccessMovingTower)
                {
                    float speed = agent.GetSpeed();
                    //agent.AdjustSpeed((float)0.5);
                    agent.AdjustSpeed((float)0.5, 3.0f, posionPrefab);
                    float speedAfter = agent.GetSpeed();
                }
            }
        }

    }
}
