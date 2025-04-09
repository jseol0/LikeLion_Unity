using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private float prallaxEffect;

    private float xPosition;
    private float length;

    void Start()
    {
        cam = Camera.main;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float distanceToMove = cam.transform.position.x * prallaxEffect;
        float distanceMoved = cam.transform.position.x * (1 - prallaxEffect);

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > xPosition + length)
            xPosition += length;
        else if (distanceMoved < xPosition - length)
            xPosition -= length;
    }
}
