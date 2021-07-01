using UnityEngine;

namespace Player.States
{
    public class FallState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            Debug.Log("FallState");
            //Play Animation
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            stateManager.TransitionToState(stateManager.IdleState);
        }

        public void Update(PlayerStateManager stateManager)
        {
            float playerAxisX = Input.GetAxis("Horizontal");
            stateManager.Rigidbody2D.velocity = new Vector2(
                playerAxisX * stateManager.MoveSpeed, 
                stateManager.Rigidbody2D.velocity.y);
            
            if (Input.GetButtonDown("Jump"))
                stateManager.jumpBufferCounter = stateManager.JumpBuffer;
            if (stateManager.CanJump && Input.GetAxisRaw("Horizontal") < 0)
                stateManager.TransitionToState(stateManager.IdleJumpState);
            else if (stateManager.CanJump && Input.GetAxisRaw("Horizontal") > 0)
                stateManager.TransitionToState(stateManager.RunJumpState);
        }
    }
}