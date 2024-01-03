using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState ActiveState { get; private set; }

    public void Init()
    {
        ChangeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveState != null)
        {
            ActiveState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (ActiveState != null)
        {
            ActiveState.Exit();
        }
        ActiveState = newState;

        if (ActiveState != null)
        {
            ActiveState.StateMachine = this;
            ActiveState.Enemy = GetComponent<Enemy>();
            ActiveState.Enter();
        }
    }
}
