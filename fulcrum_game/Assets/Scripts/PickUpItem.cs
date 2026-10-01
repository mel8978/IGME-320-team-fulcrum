using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    LayerMask targetLayer;

    public List<GameObject> inventory;
    Camera thisCamera;

    private void Awake()
    {
        thisCamera = GetComponent<Camera>();

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            Ray raycast = thisCamera.ScreenPointToRay(Mouse.current.position.value);
            RaycastHit hit;

            //transform.position, transform.forward
            if (Physics.Raycast(raycast, out hit, 20, targetLayer))
            {
                Debug.Log("Hit");
                GameObject obj = hit.collider.gameObject;
                inventory.Add(obj);
                obj.SetActive(false);
            }
        }

    }
}
