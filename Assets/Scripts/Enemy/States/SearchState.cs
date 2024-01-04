using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;

    public override void Enter()
    {
        Enemy.Agent.SetDestination(Enemy.LastKnownPlayerPosition);
    }

    public override void Perform()
    {
        // if enemy can see the player, attack player
        if (Enemy.CanSeePlayer())
        {
            StateMachine.ChangeState(new AttackState());
        }

        // if not, check if enemy is at the last known player position
        if (Enemy.Agent.remainingDistance < Enemy.Agent.stoppingDistance)
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            if (moveTimer > Random.Range(3, 7))
            {
                Enemy.Agent.SetDestination(Enemy.transform.position + Random.insideUnitSphere * 5);
                moveTimer = 0;
            }

            // if enemy has been searching for a while, change back to patrolling
            if (searchTimer > 10)
            {
                StateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
    }
}
