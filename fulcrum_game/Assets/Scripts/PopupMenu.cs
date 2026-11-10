using UnityEngine;

public class PopupMenu : MonoBehaviour
{
    // Tracks number of open popup menus across all instances
    static int openMenus = 0;

    // Hide this menu and disable cursor
    public void CloseMenu()
    {
        gameObject.SetActive(false);
        // Remove from total number of open menus
        if (openMenus == 0)
        {
            // Disable cursor if this was the only menu
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Show this menu and enable cursor
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        // Add to total number of open menus
        openMenus++;
        // Enable cursor, if necessary
        if (Cursor.lockState = CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
