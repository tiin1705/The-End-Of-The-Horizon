using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;

    public event Action<Equipment> OnRightClickEvent; 

    private Equipment _equipment;
    public Equipment equipment
    {
        get { return _equipment; }
        set { 
            _equipment = value;

            if(_equipment == null)
            {
               image.enabled = false;
            }
            else
            {
                image.sprite = _equipment.Icon;
                image.enabled = true;
            }       
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if(equipment != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(equipment);
            }
        }
    }
    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
}
