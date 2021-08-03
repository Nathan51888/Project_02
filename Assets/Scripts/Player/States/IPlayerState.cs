namespace Player.States
{
    public interface IPlayerState
    {
        void Enter(PlayerStateManager stateManager);
        void OnDetected(PlayerStateManager stateManager);
        void Update(PlayerStateManager stateManager);
    }
}