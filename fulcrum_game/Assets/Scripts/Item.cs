using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private Sprite sprite;
    [TextArea]
    [SerializeField]
    private string itemDescription;
    [SerializeField]
    LayerMask itemLayer;
    [SerializeField]
    LayerMask npcLayer;
    [SerializeField]
    Camera thisCamera;

    private InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            Ray raycast = thisCamera.ScreenPointToRay(Mouse.current.position.value);
            RaycastHit hit;

            //transform.position, transform.forward
            if (Physics.Raycast(raycast, out hit, 20, itemLayer))
            {
                Debug.Log("Hit Item");
                GameObject obj = hit.collider.gameObject;
                inventoryManager.AddItem(itemName, 1, sprite, "This is cheese");
                obj.SetActive(false);
            }

            //transform.position, transform.forward
            if (Physics.Raycast(raycast, out hit, 20, npcLayer))
            {
                Debug.Log("Hit NPC");
                GameObject obj = hit.collider.gameObject;
                //
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
    }
}
