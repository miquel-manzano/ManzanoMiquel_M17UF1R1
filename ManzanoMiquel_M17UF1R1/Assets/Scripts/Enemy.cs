using UnityEngine;
[RequireComponent(typeof(MoveBehaviour))]

public class Enemy : MonoBehaviour
{
    private MoveBehaviour _mb;

    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask obstacleLayer;
    public Transform raycastOrigin;

    private bool movingRight = true;
    public Spawner _spawner;

    public void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
    }

    void Start()
    {

    }

    void Update()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        _mb.MoveCharacter(direction);

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, direction, rayDistance, obstacleLayer);

        if (hit.collider != null)
        {
            movingRight = !movingRight;
        }

        //Debug.DrawRay(raycastOrigin.position, direction * rayDistance, Color.red);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
            _spawner.EnemiesStack.Push(gameObject);
            gameObject.SetActive(false);
        }
    }
}
