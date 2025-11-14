using System.Net.Http.Headers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MoveBehaviour : MonoBehaviour
{
    //References
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    public Animator animator;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundRayDistance;

    private bool isJumpReady = false;
    private bool isGravityInvertedReady = false;
    private Vector2 characterDirection = Vector2.down;

    private bool isGrounded = false;// I use a trigger collider to set this variable


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        //Debug.Log("Is Grounded: " + isGrounded);
        if (!isJumpReady)
        {
            if (isGrounded)
                isJumpReady = true;
            
        }
        if (!isGravityInvertedReady)
        {
            if (isGrounded)
                isGravityInvertedReady = true;
        }
        //Debug.DrawRay(transform.position, groundRayDirection * groundRayDistance, Color.red);// For debugging the ground raycast
    }

    public void MoveCharacter(Vector2 direction)
    {
        //Debug.Log("Moving character in direction: " + direction);
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
        if (isJumpReady)
        {
            //Debug.Log("Jumping character with force: " + jumpForce);

            _rb.linearVelocity = new Vector2(0f, 0f);
            _rb.AddForce((characterDirection * -1) * jumpForce, ForceMode2D.Impulse);

            isJumpReady = false;
            isGrounded = false;
        }
    }

    public void InvertGravity()
    {
        if (isGravityInvertedReady)
        {
            _rb.gravityScale *= -1;
            transform.Rotate(180f, 0f, 0f);
            _rb.AddForce((characterDirection * -1) * jumpForce, ForceMode2D.Impulse);
            characterDirection *= -1;

            isGravityInvertedReady = false;
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    /*
     * Old funground check method using Raycast
    private bool GetIsGrounded()
    {
        // Simple ground check using Raycast, toDo: improve with better ground detection using the sprite.
        return Physics2D.Raycast(transform.position, groundRayDirection, groundRayDistance, LayerMask.GetMask("Ground"));
    }
    */
}
