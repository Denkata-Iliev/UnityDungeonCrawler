using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private GameObject _projectilSpawnPoint;

    [SerializeField]
    private float _projectileSpeed = 600;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_projectilePrefab, _projectilSpawnPoint.transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(_projectilSpawnPoint.transform.forward * _projectileSpeed);
            Destroy(bullet, 1);
        }
    }
}
