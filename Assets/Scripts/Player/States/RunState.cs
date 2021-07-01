using UnityEngine;

namespace Player.States
{
    public class RunState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            Debug.Log("RunState");
            //Play animation
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            stateManager.RunParticle.Play();
        }

        public void Update(PlayerStateManager stateManager)
        {
            float playerAxisX = Input.GetAxis("Horizontal");
            stateManager.Rigidbody2D.velocity = new Vector2(
                playerAxisX * stateManager.MoveSpeed, 
                stateManager.Rigidbody2D.velocity.y);
            
            if (stateManager.Rigidbody2D.velocity.y < 0)
                stateManager.TransitionToState(stateManager.FallState);
            if (Input.GetButtonDown("Jump"))
                stateManager.jumpBufferCounter = stateManager.JumpBuffer;
            //Play animation
            if (Input.GetButtonDown("Jump") && stateManager.CanJump)
                stateManager.TransitionToState(stateManager.RunJumpState);
        }
    }
}