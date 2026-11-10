using UnityEngine;

public class PopupMenu : MonoBehaviour
{
    // Tracks number of open popup menus across all instances
    static int openMenus = 0;

    // Hide this menu and disable cursor
    public void CloseMenu()
    {
        // Skip if menu is already closed
        if (!gameObject.activeSelf) { return; }

        // Remove from total number of open menus
        openMenus--;
        if (openMenus == 0)
        {
            // Disable cursor if this was the only menu
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        // Disable the menu
        gameObject.SetActive(false);        
    }

    // Show this menu and enable cursor
    public void OpenMenu()
    {
        // Skip if menu is already open
        if (gameObject.activeSelf) { return; }

        // Enable the menu
        gameObject.SetActive(true);
        // Add to total number of open menus
        openMenus++;
        // Enable cursor, if necessary
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public static void ResetCount() { openMenus = 0; }
}
