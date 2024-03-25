using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotParent;
    [SerializeField] EquipmentSlot[] equipmentslot;


    public event Action<Item> OnItemRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i< equipmentslot.Length; i++)
        {
            equipmentslot[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }
    private void OnValidate()
    {
        equipmentslot = equipmentSlotParent.GetComponentsInChildren<EquipmentSlot>();
    }
    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentslot.Length; i++)
        {
            if (equipmentslot[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentslot[i].item;
                equipmentslot[i].item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }
    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentslot.Length; i++)
        {
            if (equipmentslot[i].item == item)
            {
                equipmentslot[i].item = null;

                return true;
            }
        }
        return false;
    }
}
