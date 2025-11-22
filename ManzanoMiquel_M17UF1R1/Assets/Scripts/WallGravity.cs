using UnityEngine;

public class WallGravity : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void ActivateGravity()
    {
        if (_rb != null)
        {
            _rb.gravityScale = 1;
        }
    }
}
