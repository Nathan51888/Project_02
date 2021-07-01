using UnityEngine;
using Player.States;

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        #region Player States

        public readonly IdleState IdleState = new IdleState();
        public readonly RunState RunState = new RunState();
        public readonly IdleJumpState IdleJumpState = new IdleJumpState();
        public readonly RunJumpState RunJumpState = new RunJumpState();
        public readonly FallState FallState = new FallState();
        public readonly HurtState hurtState = new HurtState();

        #endregion

        #region Animation

        public readonly string PLayerIdle = "Player_Idle";
        public readonly string PLayerRun = "Player_Run";
        public readonly string PLayerIdleJump = "Player_Idle_Jump";
        public readonly string PLayerRunJump = "Player_Run_Jump";
        public readonly string PLayerFall = "Player_Fall";
        public readonly string PLayerHurt = "Player_Hurt";

        #endregion

        #region Variables

        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float jumpGravity;
        [SerializeField] private float lowJumpGravity;
        [SerializeField] private float fallGravity;
        [SerializeField] private bool isFacingRight;
        [SerializeField] private float hangTime;
        [SerializeField] private float jumpBuffer;
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private ParticleSystem runParticle;
        [SerializeField] private ParticleSystem jumpParticle;
        public float hangTimeCounter;
        public float jumpBufferCounter;
        public IPlayerState CurrentState { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Animator Animator { get; private set; }
        public bool IsGrounded { get; private set; }
        public float MoveSpeed => moveSpeed;
        public float JumpHeight => jumpHeight;
        public float HangTime => hangTime;
        public float JumpBuffer => jumpBuffer;
        public ParticleSystem RunParticle => runParticle;
        public ParticleSystem JumpParticle => runParticle;
        public bool CanJump => jumpBufferCounter > 0 && hangTimeCounter > 0;
        private string _currentAnimation;

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            TransitionToState(IdleState);
            if (Timer.Instance == null)
                return;
            Timer.Instance.StartTimer();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Respawn"))
                GameManager.Instance.Respawn();
            hangTimeCounter -= Time.deltaTime;
            jumpBufferCounter -= Time.deltaTime;
            GroundCheck();
            CurrentState.OnDetected(this);
            CurrentState.Update(this);
            ChangeGravity();
        }

        #endregion

        #region Class Method

        private void GroundCheck()
        {
            var position = transform.position;
            IsGrounded = Physics2D.OverlapBox(
                new Vector2(position.x, position.y - 1f),
                new Vector2(0.7f, 0.4f),
                0, groundLayers);
            if (IsGrounded)
                hangTimeCounter = hangTime;
        }

        public void ChangeGravity()
        {
            if (Rigidbody2D.velocity.y < 0)
                Rigidbody2D.gravityScale = fallGravity;
            else if (!Input.GetButton("Jump") && Rigidbody2D.velocity.y > 0)
                Rigidbody2D.gravityScale = lowJumpGravity;
            else
                Rigidbody2D.gravityScale = jumpGravity;
        }
        
        public void TransitionToState(IPlayerState state)
        {
            CurrentState = state;
            CurrentState.Enter(this);
        }

        public void ChangeAnimation(string nextAnimation)
        {
            // Return if animation is the same
            if (_currentAnimation == nextAnimation) return;
            Animator.Play(nextAnimation, 0);
            _currentAnimation = nextAnimation;
        }

        #endregion
    }
}