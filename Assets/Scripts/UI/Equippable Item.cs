using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Boots,
    Weapon,
    Accessory,
}
[CreateAssetMenu]
public class EquippableItem : Equipment
{
    public int StrengthBonus;
    public int AgilityBonus;
    public int IntelligenceBonus;
    public int VitalityBonus;
    [Space]
    public float StrengthPercentBonus;
    public float AgilityPercentBonus;
    public float IntelligencePercentBonus;
    public float VitalityPercentBonus;
    [Space]
    public EquipmentType EquipmentType;
}
