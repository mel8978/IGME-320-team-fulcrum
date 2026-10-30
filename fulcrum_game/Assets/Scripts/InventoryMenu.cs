using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    // Number of item boxes in the hotbar
    [SerializeField] private int numItems;

    // Holds prefab for the item boxes in the hotbar
    [SerializeField] private GameObject itemBoxPrefab;
    // Holds reference to grid layout
    [SerializeField] private GameObject itemBoxGrid;

    // Holds a reference to all item boxes in the hotbar
    private List<GameObject> itemBoxes;

    private int selectedIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemBoxes = new List<GameObject>();

        // Add numItems number of item boxes to the itemBoxes list, and assign as a child
        for (int i = 0; i < numItems; i++)
        {
            GameObject itemBox = Instantiate(itemBoxPrefab, itemBoxGrid.transform);
            itemBoxes.Add(itemBox);
        }

        selectedIndex = 0;

        // Force layout to recompute and update selector box position
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);

        UpdateSelected();
    }

    // Update is called once per frame
    void Update()
    {
        // Add game logic here
    }

    private void UpdateSelected()
    {
        // Add behavior for re-selecting inventory items here
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }

    public int GetNumItems()
    {
        return numItems;
    }
}
