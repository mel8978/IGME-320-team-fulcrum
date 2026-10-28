using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHotbar : MonoBehaviour
{
    // Number of item boxes in the hotbar
    public int numItems;

    // Holds prefab for the item boxes in the hotbar
    [SerializeField] private GameObject itemBoxPrefab;

    // Holds a reference to all item boxes in the hotbar
    private List<GameObject> itemBoxes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemBoxes = new List<GameObject>();

        // Add numItems number of item boxes to the itemBoxes list, and assign as a child
        for (int i = 0; i < numItems; i++)
        {
            GameObject itemBox = Instantiate(itemBoxPrefab, transform);
            itemBoxes.Add(itemBox);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
