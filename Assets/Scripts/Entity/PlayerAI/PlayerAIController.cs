/*
    Programmer: Pedro Longo
*/

using UnityEngine;

public class PlayerAIController : AIController
{
    protected override void OnStart()
    {
        m_Shooting = GetComponentInChildren<PlayerAIShooting>();
    }

    protected override void Pursue()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, m_MoveSpeed * Time.deltaTime);
    }

    protected override void Evade()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, -m_MoveSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // If the target exists, run
        if (target != null)
        {
            // Get distance from target
            float distanceFromTarget = Vector2.Distance(target.position, transform.position);

            if(distanceFromTarget >= m_ShootingRange)
                Pursue();

            // Only evade if the target is NOT a player
            //else if(!target.CompareTag("Player"))
            //    if (distanceFromTarget < m_ShootingRange && distanceFromTarget >= range)
            //        Evade();
        }
    }
}
