using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotParent;
    [SerializeField] Slot[] slot;

    public event Action<Equipment> OnItemRightClickEvent;
    private void OnValidate()
    {
        slot = equipmentSlotParent.GetComponentsInChildren<Slot>();
    }
    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)slot[i].equipment;
                slot[i].equipment = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }
    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].equipment == item)
            {
                slot[i].equipment = null;
                return true;
            }
        }
        return false;
    }
}
