using System.Collections;
using UnityEngine;

namespace Player.States
{
    public class HurtState : MonoBehaviour, IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            StartCoroutine(OnDeath(stateManager));
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
        }

        public void Update(PlayerStateManager stateManager)
        {
            OnDeath(stateManager);
        }

        private IEnumerator OnDeath(PlayerStateManager stateManager)
        {
            //Play animation
            stateManager.Rigidbody2D.velocity = Vector2.zero;
            yield return new WaitForSeconds(4);

            GameManager.Instance.Respawn();
            stateManager.TransitionToState(stateManager.FallState);
        }
    }
}