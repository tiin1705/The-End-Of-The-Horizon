using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : EquipmentSlot
{
    public EquipmentType EquipmentType;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";

    }
}
