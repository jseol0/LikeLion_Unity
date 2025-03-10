using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr.position = new Vector3(target.position.x, tr.position.y, target.position.z - 10);

        tr.LookAt(target);
    }
}
