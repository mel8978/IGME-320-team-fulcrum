using UnityEngine;

public class DefaultCanvasMenuManager : MonoBehaviour
{
    [SerializeField] private PopupMenu pauseMenu;
    [SerializeField] private PopupMenu inventoryMenu;

    // Reset number of menus on awake
    void Awake() 
    {
        PopupMenu.ResetCount();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Use old input system to open menus
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.OpenMenu();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryMenu.OpenMenu();
        }
    }
}
