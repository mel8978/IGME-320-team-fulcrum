using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryHotbar : MonoBehaviour
{
    // Holds prefab for the item boxes in the hotbar
    [SerializeField] private GameObject itemBoxPrefab;
    [SerializeField] private GameObject itemSelector;

    // Holds a reference to all item boxes in the hotbar
    private List<GameObject> itemBoxes;

    private int selectedIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize fields
        selectedIndex = 0;
        itemBoxes = new List<GameObject>();

        // Populate list of item boxes
        Transform[] descendants = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform childTransform in descendants)
        {
            GameObject child = childTransform.gameObject;

            // If a child shares a name with the provided item box prefab, add it
            if(child.name == itemBoxPrefab.name)
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
        float scrollY = Input.mouseScrollDelta.y;

        // Move selector on scroll
        if (scrollY > 0f) // scroll up = move selector right
        {
            selectedIndex++;
            if (selectedIndex > itemBoxes.Count - 1)
            {
                selectedIndex = 0;
            }
            UpdateSelected();
        }
        else if (scrollY < 0f) // scroll down = move selector left
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = itemBoxes.Count - 1;
            }
            UpdateSelected();
        }
    }

    /// <summary>
    /// Move selector to the position of the currently selected list item
    /// </summary>
    private void UpdateSelected()
    {
        Vector3 targetPosition = itemBoxes[selectedIndex].transform.position;
        itemSelector.transform.position = targetPosition;
    }

    /// <summary>
    /// Retrieve a reference to the currently selected item
    /// </summary>
    /// <returns>Reference to an item box prefab instance</returns>
    public GameObject GetSelected()
    {
        return itemBoxes[selectedIndex];
    }

    /// <summary>
    /// Retrieve the index of the currently selected item
    /// </summary>
    /// <returns>Int corresponding to the location of the item box prefab in the hotbar</returns>
    public int GetSelectedIndex()
    {
        return selectedIndex;
    }

    /// <summary>
    /// Get the total number of items in the hotbar
    /// </summary>
    /// <returns>Total number of items in the hotbar</returns>
    public int GetNumItems()
    {
        return itemBoxes.Count;
    }
}
