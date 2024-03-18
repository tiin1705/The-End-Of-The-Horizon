using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Equipment> equipments;
    [SerializeField] Transform equipmentParent;
    [SerializeField] EquipmentSlot[] equipmentSlot;

    public event Action<Equipment> OnRightClickedEvent;
    private void OnValidate()
    {
        if(equipmentParent != null)
            equipmentSlot = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        RefreshUI();
    }
    private void Awake()
    {
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].OnRightClickEvent += OnRightClickedEvent;
        }
    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i < equipments.Count && i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].equipment = equipments[i]; 
        }
        
        for(; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].equipment = null;
        }
    }

    public bool AddEquipment(Equipment equipment)
    {
        if (IsFull())
            return false;
        equipments.Add(equipment);
        RefreshUI();
        return true;
    }

    public bool RemoveEquipment(Equipment equipment)
    {
        if (equipments.Remove(equipment))
        {
            RefreshUI();
            return true;
        }
        return false;
    }
    public bool IsFull()
    {
        return equipments.Count >= equipmentSlot.Length;
    }
}
