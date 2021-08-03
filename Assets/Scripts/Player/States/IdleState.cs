using UnityEngine;

namespace Player.States
{
    public class IdleState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            Debug.Log("IdleState");
            stateManager.RunParticle.Stop();
            //stateManager.ChangeAnimation(stateManager.PLayerIdle);
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            if (!stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.FallState);
        }

        public void Update(PlayerStateManager stateManager)
        {
            var playerAxisX = Input.GetAxis("Horizontal");
            stateManager.Rigidbody2D.velocity = new Vector2(
                playerAxisX * stateManager.MoveSpeed,
                stateManager.Rigidbody2D.velocity.y);

            if (Input.GetAxisRaw("Horizontal") != 0 && stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.RunState);
            if (stateManager.Rigidbody2D.velocity.y < 0)
                stateManager.TransitionToState(stateManager.FallState);
            if (Input.GetButtonDown("Jump"))
                stateManager.jumpBufferCounter = stateManager.JumpBuffer;

            if (stateManager.CanJump)
                stateManager.TransitionToState(stateManager.IdleJumpState);
        }
    }
}