public abstract class BaseState
{
    public StateMachine StateMachine { get; set; }

    public Enemy Enemy { get; set; }

    public abstract void Enter();

    public abstract void Perform();

    public abstract void Exit();
}