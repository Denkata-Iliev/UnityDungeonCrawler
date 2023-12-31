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
        if (Enemy.IsDead())
        {
            return;
        }

        if (Enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;

            Enemy.transform.LookAt(Enemy.Player.transform); // lock to the player

            if (shotTimer > Enemy.fireRate)
            {
                Enemy.Animator.SetTrigger("Attack");
                Shoot();
                Enemy.Animator.SetTrigger("Move");
            }

            // move to a random position after some time
            if (moveTimer > Random.Range(3, 5))
            {
                Enemy.Agent.SetDestination(Enemy.transform.position + Random.insideUnitSphere * 10);
                moveTimer = 0;
            }

            Enemy.LastKnownPlayerPosition = Enemy.Player.transform.position;
        }
        else // lost sight of player
        {
            losePlayerTimer += Time.deltaTime;

            if (losePlayerTimer > 8)
            {
                // change to search state
                StateMachine.ChangeState(new SearchState());
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
        // if it's a boss, instantiate 20 projectiles
        List<GameObject> projectiles = new();
        if (Enemy.CompareTag("Boss"))
        {
            for (int i = 0; i < 20; i++)
            {
                projectiles.Add(GameObject.Instantiate(Enemy.projectilePrefab, spawnPoint.position, Enemy.transform.rotation));
            }
        }
        // instantiate a new projectile
        GameObject projectile = GameObject.Instantiate(Enemy.projectilePrefab, spawnPoint.position, Enemy.transform.rotation);

        // calculate the direction to the player
        Vector3 shootDirection = (Enemy.Player.transform.position - spawnPoint.transform.position).normalized;

        // add force to the rigidbody component
        // if it's a boss, shoot the projectiles closer to the player
        if (projectiles.Count > 0 && Enemy.CompareTag("Boss"))
        {
            foreach (var proj in projectiles)
            {
                proj.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-2f, 2f), Vector3.up) * shootDirection * 40;
            }
        }
        projectile.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-5f, 5f), Vector3.up) * shootDirection * 40;

        shotTimer = 0;
    }
}
