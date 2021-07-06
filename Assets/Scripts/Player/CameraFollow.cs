using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0.0f,2.35f,-6.6f);
    [SerializeField] [Range(0.01f, 1f)]private float smoothSpeed = 0.2f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        //Vector3 desiredPosition = new Vector3(target.position.x, target.position.y,transform.position.z) + offset;
        //Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothPosition;
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z) + offset;
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
    }
}
