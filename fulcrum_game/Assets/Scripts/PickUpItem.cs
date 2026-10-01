using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    LayerMask targetLayer;

    Camera thisCamera;

    private void Awake()
    {
        thisCamera = GetComponent<Camera>();

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("pressed fire");
        if (context.phase == InputActionPhase.Canceled)
        {
            Ray raycast = thisCamera.ScreenPointToRay(Mouse.current.position.value);
            RaycastHit hit;

            Debug.Log("pressed fire");
            //transform.position, transform.forward
            if (Physics.Raycast(raycast, out hit, 20, targetLayer))
            {
                Debug.Log("Hit");
                GameObject obj = hit.collider.gameObject;
                obj.SetActive(false);
            }
        }

    }
}
