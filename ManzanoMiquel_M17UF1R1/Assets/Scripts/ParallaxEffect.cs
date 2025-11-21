using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxFactor;
    [SerializeField] private bool canDuplicate = true;

    private Transform cameraTransform;
    Vector3 previousCameraPosition;
    private float spriteWidth, startPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * parallaxFactor;
        float moveAmount = cameraTransform.position.x * (1 - parallaxFactor);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;

        // Horizontal Parallax Duplication
        if (canDuplicate)
        {
            if (moveAmount > startPosition + spriteWidth)
            {
                transform.Translate(new Vector3(spriteWidth, 0, 0));
                startPosition += spriteWidth;
            }
            else if (moveAmount < startPosition - spriteWidth)
            {
                transform.Translate(new Vector3(-spriteWidth, 0, 0));
                startPosition -= spriteWidth;
            }
        }

        //Vertical Parallax
    }
}
