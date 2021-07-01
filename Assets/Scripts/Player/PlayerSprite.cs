using UnityEngine;

namespace Player
{
    public class PlayerSprite : MonoBehaviour
    {
        private bool _isFacingRight = true;

        private void Update()
        {
            FlipPlayer();
        }

        private void FlipPlayer()
        {
            if (_isFacingRight && Input.GetAxisRaw("Horizontal") < 0)
            {
                FlipTransform(transform);
                _isFacingRight = !_isFacingRight;
            }
            else if (!_isFacingRight && Input.GetAxisRaw("Horizontal") > 0)
            {
                FlipTransform(transform);
                _isFacingRight = !_isFacingRight;
            }
        }

        private void FlipTransform(Transform transformToFlip)
        {
            var theScale = transformToFlip.localScale;
            theScale.x *= -1;
            transformToFlip.localScale = theScale;
        }
    }
}