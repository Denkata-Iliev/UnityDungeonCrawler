using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState activeState;
    private PatrolState patrolState;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState is not null)
        {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState is not null)
        {
            activeState.Exit();
        }
        activeState = newState;

        if (activeState is not null)
        {
            activeState.StateMachine = this;
            activeState.Enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }

    public void Init()
    {
        patrolState = new();
        ChangeState(patrolState);
    }
}
