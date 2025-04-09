using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;

    void Start()
    {
        cam = Camera.main;

        xPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > xPosition + length)
            xPosition += length;
        else if (distanceMoved < xPosition - length)
            xPosition -= length;
    }
}
