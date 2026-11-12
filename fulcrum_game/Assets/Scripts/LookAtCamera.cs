using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtPos = cameraTransform.position;
        lookAtPos.y = transform.position.y;
        transform.LookAt(lookAtPos);
    }
}
