using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;



    private void Awake()
    {
        inventory.OnRightClickedEvent += EquipFromInventory();

    }

    private void EquipFromInventory(Equipment item)
    {
        if(item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }
    public void Equip(EquippableItem item)
    {
        if(inventory.RemoveEquipment(item))
        {
            EquippableItem previousItem;
            if(equipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddEquipment(previousItem);
                }
            }
            else
            {
                inventory.AddEquipment(item);
            }
        }
    }
    
    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull()&& equipmentPanel.RemoveItem(item))
        {
            inventory.AddEquipment(item);
        }
    }
}
