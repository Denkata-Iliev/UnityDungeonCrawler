using UnityEngine;
using UnityEngine.AI;
using Vitals;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private Health health;

    // just for debugging
    [SerializeField]
    private string currentState;

    public NavMeshAgent Agent { get; private set; }
    public GameObject Player { get; private set; }
    public Vector3 LastKnownPlayerPosition { get; set; }

    public Path path;
    public GameObject projectilePrefab;

    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;

    [Header("Attack Values")]
    public Transform projectileSpawnPoint;

    [Range(0.1f, 10f)]
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        health = GetComponent<Health>();

        stateMachine.Init();
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();

        currentState = stateMachine.ActiveState.ToString();
        if (health.Value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool CanSeePlayer()
    {
        if (Player != null)
        {
            // is the player close enough to be seen
            if (Vector3.Distance(transform.position, Player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = Player.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                // is the player in the field of view
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new(transform.position, targetDirection);

                    // is the line of sight is blocked by an object
                    if (Physics.Raycast(ray, out var hitInfo, sightDistance))
                    {
                        // is that object the player
                        if (hitInfo.transform.gameObject == Player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PlayerProjectile"))
        {
            health.Decrease(5f);
        }
    }
}
