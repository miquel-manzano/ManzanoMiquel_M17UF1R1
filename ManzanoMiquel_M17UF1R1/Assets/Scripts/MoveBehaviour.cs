using System.Net.Http.Headers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRayDistance;
    public Animator animator;

    private bool isGrounded;
    private bool jump;
    private bool powerUp;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        
    }

    public void MoveCharacter(Vector2 direction)
    {
        Debug.Log("Moving character in direction: " + direction);
        _rb.linearVelocity = new Vector2(direction.normalized.x * speed, _rb.linearVelocity.y);

        if (animator != null)
        {
            if (direction.x < 0)
            {
                _sr.flipX = true;
            }
            else
            {
                _sr.flipX = false;
            }
            animator.SetFloat("Speed", Mathf.Abs(direction.x));
        }
    }

    public void JumpCharacter()
    {
        if (GetIsGrounded())
        {
            Debug.Log("Jumping character with force: " + jumpForce);
            
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void PowerUp()
    {
        if (GetIsGrounded())
        {
            _rb.gravityScale *= -1;
        }
    }

    private bool GetIsGrounded()
    {
        // Simple ground check using Raycast, toDo: improve with better ground detection using the sprite.
        return Physics2D.Raycast(transform.position, Vector2.down, jumpRayDistance, LayerMask.GetMask("Ground"));
    }
}
