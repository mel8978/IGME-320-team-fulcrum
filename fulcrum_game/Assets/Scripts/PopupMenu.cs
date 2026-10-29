using UnityEngine;

public class PopupMenu : MonoBehaviour
{
    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
    }
}
