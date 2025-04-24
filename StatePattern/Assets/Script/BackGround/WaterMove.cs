using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public Transform player;
    private Vector3 lastCameraPosition;
    private float xPosition;

    void Start()
    {
        lastCameraPosition = player.transform.position;
    }

    void Update()
    {
        Vector3 delta = player.position - lastCameraPosition;

        // x축 이동만 적용
        transform.position += new Vector3(delta.x, 0f, 0f);

        lastCameraPosition = player.position;
    }
}
