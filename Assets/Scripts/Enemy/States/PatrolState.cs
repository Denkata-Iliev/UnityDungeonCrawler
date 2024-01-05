using UnityEngine;

public class PatrolState : BaseState
{
    private int waypointIndex;
    private float waitTime;

    public override void Enter()
    {
    }

    public override void Perform()
    {
        PatrolCycle();

        if (Enemy.CanSeePlayer())
        {
            StateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
        // waypoint is far, make the enemy walk
        if (Enemy.Agent.remainingDistance > 0.2f)
        {
            return;
        }

        // reached waypoint, so enemy stops walking and idles
        waitTime += Time.deltaTime;
        if (waitTime > 3)
        {
            // after 3s, enemy starts going to the next waypoint
            if (waypointIndex < Enemy.path.waypoints.Count - 1)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex = 0;
            }

            Enemy.Agent.SetDestination(Enemy.path.waypoints[waypointIndex].position);
            waitTime = 0;
        }
    }
}
