namespace Assets.Scripts.Gameplay.Units.Towers
{
    public class MageTowerAttack : TowerAttack
    {

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
                    agent.AdjustSpeed((float)0.5);
                    float speedAfter = agent.GetSpeed();
                }
            }
        }

    }
}
