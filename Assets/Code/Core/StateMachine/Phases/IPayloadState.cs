namespace Code.Core.StateMachine.Phases
{
    public interface IPayloadState<in T>
    {
        public void Enter(T payload);
    }
}