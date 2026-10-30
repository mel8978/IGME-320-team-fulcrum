using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
//using UnityEditor.PackageManager;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    LayerMask targetLayer1;

    [SerializeField]
    LayerMask targetLayer2;

    public List<GameObject> inventory;
    Camera thisCamera;

    [SerializeField]
    Image cheese;

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
            if (Physics.Raycast(raycast, out hit, 20, targetLayer1))
            {
                Debug.Log("Hit Item");
                GameObject obj = hit.collider.gameObject;
                inventory.Add(obj);
                obj.SetActive(false);
            }

            //transform.position, transform.forward
            if (Physics.Raycast(raycast, out hit, 20, targetLayer2))
            {
                Debug.Log("Hit NPC");
                GameObject obj = hit.collider.gameObject;
                if(inventory.Count!=0)
                {
                    inventory.Remove(inventory[inventory.Count-1]);  
                }          
            }
        }

    }

    private void Update()
    {
        if(inventory.Count != 0)
        {

            cheese.enabled = true;
        }
        else
        {
            cheese.enabled = false;
        }
    }
}
