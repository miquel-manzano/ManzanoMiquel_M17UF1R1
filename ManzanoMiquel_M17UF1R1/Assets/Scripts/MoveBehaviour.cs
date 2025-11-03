using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRayDistance;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 direction)
    {
        Debug.Log("Moving character in direction: " + direction);
        _rb.linearVelocity = new Vector2(direction.normalized.x * speed, _rb.linearVelocity.y);
    }

    public void JumpCharacter()
    {
        if (GetIsGrounded())
        {
            Debug.Log("Jumping character with force: " + jumpForce);
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool GetIsGrounded()
    {
        // Simple ground check using Raycast, toDo: improve with better ground detection using the sprite.
        return Physics2D.Raycast(transform.position, Vector2.down, jumpRayDistance, LayerMask.GetMask("Ground"));
    }
}
