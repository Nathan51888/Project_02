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

        IEnumerator OnDeath(PlayerStateManager stateManager)
        {
            //Play animation
            stateManager.Rigidbody2D.velocity = Vector2.zero;
            yield return new WaitForSeconds(4);
            
            GameManager.Instance.Respawn();
        }
        
        public void OnDetected(PlayerStateManager stateManager)
        {
            
        }

        public void Update(PlayerStateManager stateManager)
        {
            
        }
    }
}