using UnityEngine;

public class GravityZoneTrigger : MonoBehaviour
{
    public WallGravity Wall;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.DisableInvertGravity();
        }
        Debug.Log("NOENTRA EN IF");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.EnableInvertGravity();
            Wall.ActivateGravity();
        }
    }
}
