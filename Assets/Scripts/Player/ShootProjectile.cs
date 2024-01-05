using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private GameObject projectilSpawnPoint;

    [SerializeField]
    private float projectileSpeed = 600;

    private readonly float fireRate = 0.3f;
    private float shotTimer;

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > fireRate)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(projectilePrefab,
                projectilSpawnPoint.transform.position,
                transform.rotation);

            bullet.GetComponent<Rigidbody>()
                .AddForce(projectilSpawnPoint.transform.forward * projectileSpeed);

            Destroy(bullet, 1);
            shotTimer = 0;
        }
    }
}
