/*
    Programmer: Manhattan Calabro
*/

using UnityEngine.AI;

public class EnemyDisable : BaseDisable
{
    // Disables the enemy
    public override void DisableEntity()
    {
        DisableVelocity();

        // Disable the enemy's movement
        if(GetComponentInChildren<EnemyController>() != null)
        {
            GetComponentInChildren<EnemyController>().enabled = false;

            // Disable the agent
            if(GetComponentInChildren<NavMeshAgent>() != null)
                GetComponentInChildren<NavMeshAgent>().enabled = false;

            // Disable the attack script
            if(GetComponentInChildren<EnemyShooting>() != null)
                GetComponentInChildren<EnemyShooting>().enabled = false;
            if(GetComponentInChildren<EnemyShootingBurst>() != null)
                GetComponentInChildren<EnemyShootingBurst>().enabled = false;
            if(GetComponentInChildren<EnemyExplosive>() != null)
                GetComponentInChildren<EnemyExplosive>().enabled = false;
        }

        // Otherwise, the enemy is a boss
        else
        {
            // Disable the boss scripts
            if(GetComponentInChildren<BossAI>() != null)
                GetComponentInChildren<BossAI>().enabled = false;
            if(GetComponentInChildren<BossAttacks>() != null)
                GetComponentInChildren<BossAttacks>().enabled = false;
        }
    }
}
