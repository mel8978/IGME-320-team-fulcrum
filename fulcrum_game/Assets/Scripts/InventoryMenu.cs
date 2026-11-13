using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    // Holds prefab for the item boxes in the hotbar
    [SerializeField] private GameObject itemBoxPrefab;
    [SerializeField] private GameObject itemSelector;
    // Holds reference to grid layout
    [SerializeField] private GameObject itemBoxGrid;

    // Holds a reference to all item boxes in the hotbar
    private List<GameObject> itemBoxes;

    private int selectedIndex;

    // Start causes an error because it runs after OnEnable, so Awake is used instead
    void Start()
    {
        selectedIndex = 0;
        itemBoxes = new List<GameObject>();

        // Populate list of item boxes
        Transform[] descendants = itemBoxGrid.GetComponentsInChildren<Transform>();
        foreach (Transform childTransform in descendants)
        {
            GameObject child = childTransform.gameObject;

            // If a child shares a name with the provided item box prefab, add it
            if (child.name == itemBoxPrefab.name)
            {
                itemBoxes.Add(child);
            }
        }

        // Force layout to recompute and update selector box position
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);

        UpdateSelected();
    }

    // Update is called once per frame
    void Update()
    {
        // Add selection functionality here?
    }

    // This code might not be necessary. Ideally would rebuild and update menu
    // every time it is displayed onscreen
    private void OnEnable()
    {
        // Force layout to recompute and update selector box position
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        // Make sure item selector is in the correct spot when the menu is shown
        UpdateSelected();
    }

    private void UpdateSelected()
    {
        // Add selection behavior here?
        /*
        Vector3 targetPosition = itemBoxes[selectedIndex].transform.position;
        itemSelector.transform.position = targetPosition;
        */
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }

    public int GetNumItems()
    {
        return itemBoxes.Count;
    }
}
