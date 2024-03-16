using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Equipment> equipment;
    [SerializeField] Transform equipmentParent;
    [SerializeField] EquipmentSlot[] equipmentSlot;

    private void OnValidate()
    {
        if(equipmentParent != null)
            equipmentSlot = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i < equipment.Count && i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].equipment = equipment[i]; 
        }
        
        for(; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].equipment = null;
        }
    }

}
