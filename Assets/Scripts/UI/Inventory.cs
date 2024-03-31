using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemParent;
    [SerializeField] ItemSlot[] itemtSlot;

    public event Action<Item>OnItemRightClickedEvent;
    private void OnValidate()
    {
        if(itemParent != null)
            itemtSlot = itemParent.GetComponentsInChildren<ItemSlot>();
        RefreshUI();
    }
    private void Awake()
    {
        for (int i = 0; i < itemtSlot.Length; i++)
        {
            itemtSlot[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i < items.Count && i < itemtSlot.Length; i++)
        {
            itemtSlot[i].item = items[i]; 
        }
        
        for(; i < itemtSlot.Length; i++)
        {
            itemtSlot[i].item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if (IsFull())
            return false;
        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }
    public bool IsFull()
    {
        return items.Count >= itemtSlot.Length;
    }
}
