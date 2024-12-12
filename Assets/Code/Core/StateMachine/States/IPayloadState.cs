namespace Code.Core.StateMachine.States
{
    public interface IPayloadState<in T>
    {
        public void Enter(T payload);
    }
}