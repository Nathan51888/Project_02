using UnityEngine;

namespace Player.States
{
    public class IdleJumpState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            Debug.Log("IdleJumpState");
            //Play animation
            stateManager.hangTimeCounter = 0;
            stateManager.jumpBufferCounter = 0;
            stateManager.JumpParticle.Play();
            stateManager.Rigidbody2D.velocity = Vector2.up * stateManager.JumpHeight;
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            stateManager.TransitionToState(stateManager.IdleState);
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (stateManager.Rigidbody2D.velocity.y < 0)
                stateManager.TransitionToState(stateManager.FallState);
        }
    }
}