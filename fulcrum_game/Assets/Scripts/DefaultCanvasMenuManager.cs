using UnityEngine;

public class DefaultCanvasMenuManager : MonoBehaviour
{
    [SerializeField] private PopupMenu pauseMenu;
    [SerializeField] private PopupMenu inventoryMenu;
    [SerializeField] private GameObject hotbar;

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
            if(pauseMenu.gameObject.activeSelf == false)
            {
                pauseMenu.OpenMenu();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryMenu.gameObject.activeSelf == false)
            {
                inventoryMenu.OpenMenu();
                //hotbar.SetActive(false);
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(inventoryMenu.gameObject.activeSelf == false && hotbar.activeSelf == false)
            {
                //hotbar.SetActive(true);
            }
        }
    }
}
