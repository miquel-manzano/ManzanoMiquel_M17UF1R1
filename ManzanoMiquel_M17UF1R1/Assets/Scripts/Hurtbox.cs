using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("HitboxPlayer"))
        {
            Debug.Log("Hit detected with " + collision.gameObject.name);

            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.Die();
            }
        }
    }
}
