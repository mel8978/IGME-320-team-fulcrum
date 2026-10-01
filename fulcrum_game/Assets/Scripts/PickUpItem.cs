using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    LayerMask targetLayer;
    [SerializeField]
    TextMeshProUGUI itemText;

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

    private void Update()
    {
        if(inventory.Count != 0)
        {
            itemText.text = "Item in Inventory";
        }
        else
        {
            itemText.text = "";
        }
    }
}
