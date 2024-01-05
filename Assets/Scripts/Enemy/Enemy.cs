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
    public Animator Animator { get; private set; }

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
        Animator = GetComponent<Animator>();

        stateMachine.Init();
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("Speed", Agent.velocity.magnitude);

        currentState = stateMachine.ActiveState.ToString();
        if (IsDead())
        {
            Animator.SetTrigger("Death");
            Destroy(gameObject, 3);
        }
    }

    public bool CanSeePlayer()
    {
        if (Player == null)
        {
            return false;
        }

        // player is too far to be seen
        if (Vector3.Distance(transform.position, Player.transform.position) > sightDistance)
        {
            return false;
        }

        Vector3 targetDirection = Player.transform.position - transform.position;
        float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

        // player is OUTSIDE of the field of view
        if (angleToPlayer < -fieldOfView || angleToPlayer > fieldOfView)
        {
            return false;
        }

        Ray ray = new(transform.position, targetDirection);

        // is the line of sight blocked by an object
        if (Physics.Raycast(ray, out var hitInfo, sightDistance))
        {
            // is that object the player
            if (hitInfo.transform.gameObject == Player)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsDead()
    {
        return health.Value == 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PlayerProjectile"))
        {
            health.Decrease(5f);
            Animator.SetTrigger("Damaged");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Animator.SetTrigger("Move");
    }
}
