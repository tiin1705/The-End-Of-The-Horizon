using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] Image image;

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


    private void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
}
