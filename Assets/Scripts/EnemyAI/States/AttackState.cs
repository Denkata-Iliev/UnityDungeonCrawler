using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

    public override void Enter()
    {
    }

    public override void Perform()
    {
        if (Enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;

            Enemy.transform.LookAt(Enemy.Player.transform); // lock to the player

            if (shotTimer > Enemy.fireRate)
            {
                Shoot();
            }

            // move to a random position after some time
            if (moveTimer > Random.Range(3, 7))
            {
                Enemy.Agent.SetDestination(Enemy.transform.position + Random.insideUnitSphere * 5);
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;

            if (losePlayerTimer > 8)
            {
                // change to search state
                StateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Exit()
    {
    }

    public void Shoot()
    {
        // store reference to the projectile spawnpoint
        Transform spawnPoint = Enemy.projectileSpawnPoint;

        // instantiate a new projectile
        GameObject projectile = GameObject.Instantiate(Enemy.projectilePrefab, spawnPoint.position, Enemy.transform.rotation);

        // calculate the direction to the player
        Vector3 shootDirection = (Enemy.Player.transform.position - spawnPoint.transform.position).normalized;

        // add force to the rigidbody component
        projectile.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40;

        shotTimer = 0;
    }
}
