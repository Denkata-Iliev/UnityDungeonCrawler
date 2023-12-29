using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;

    // just for debugging
    [SerializeField]
    private string currentState;

    public NavMeshAgent Agent { get; private set; }

    public Path path;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        Agent = GetComponent<NavMeshAgent>();

        stateMachine.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
