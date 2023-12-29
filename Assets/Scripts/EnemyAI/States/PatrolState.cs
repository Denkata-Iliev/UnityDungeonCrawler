using UnityEngine;

public class PatrolState : BaseState
{
    private int waypointIndex;
    private float waitTime;
    private Animator animator;

    public override void Enter()
    {
        animator = Enemy.GetComponent<Animator>();
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public override void Exit()
    {
    }

    public void PatrolCycle()
    {
        // waypoint is far, make the enemy walk
        if (Enemy.Agent.remainingDistance > 0.2f)
        {
            StartWalkingAnim();
            return;
        }

        // reached waypoint, so enemy stops walking and idles
        StopWalkingAnim();
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
            StartWalkingAnim();
        }
    }

    private void StartWalkingAnim()
    {
        animator.SetTrigger("StartWalking");
    }

    private void StopWalkingAnim()
    {
        animator.SetTrigger("StopWalking");
    }
}
