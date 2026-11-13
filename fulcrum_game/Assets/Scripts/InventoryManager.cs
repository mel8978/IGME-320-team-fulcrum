using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;

    public ItemSO[] itemSOs;

    public ItemSlot[] itemSlots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            // activates
            //Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            // deactivates
            //Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        } */
    }

    public void OpenInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            if (menuActivated)
            {
                // activates
                Time.timeScale = 1;
                InventoryMenu.SetActive(false);
                menuActivated = false;
            }
            else if (!menuActivated)
            {
                // deactivates
                Time.timeScale = 0;
                InventoryMenu.SetActive(true);
                menuActivated = true;
            }
        }
    }

    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
            }    
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log("InventoryManager.AddItem");
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].isFull == false)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                Debug.Log("item added");
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }
}
