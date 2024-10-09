using UI.GameMenu;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Constant Character Fields")]
        [SerializeField] private Rigidbody2D _playerRB;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private Animator _animator;
    
        [Header("Relative Characters Fields")]
        [SerializeField] private float _jumpForce = 1;
        [SerializeField] private bool _isPlayerGrounded;

        private void Awake()
        {
            _isPlayerGrounded = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_isPlayerGrounded)
                {
                    _playerRB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                    _isPlayerGrounded = false;
                    _animator.Play("Jump");
                }
            }
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (!_isPlayerGrounded)
                {
                    _isPlayerGrounded = true;
                    _animator.Play("Run");
                }
            }
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                //GameManager.Instance.SetPlayerAlive(false);
                GameMenuManager.Instance.SetPlayerAlive(false);
                Time.timeScale = 0;
                //GameManager.Instance.DisplayGameOver();
                GameMenuManager.Instance.DisplayGameOver();
            }
        }
    }
}