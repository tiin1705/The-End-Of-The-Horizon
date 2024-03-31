using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int Level = 1;
    public int HP = 100;
    public int maxHP = 100;
    public int MP = 50;
    public int maxMP = 50;
    public int STR = 3;
    public int SPD = 5;
    public int Experience = 0;
    public int SkillPoint = 0;

   

    public void GainExperience(int exp)
    {
        Experience += exp;
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if(Experience >= 100 * Level)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        Level++;
        Experience = 0;
        SkillPoint += 3;

    }

    public void InscreaseHP(int amount)
    {
        if(SkillPoint > 0)
        {
            HP += amount;
            SkillPoint--;
        }
    }

    public void InscreaseSTR(int amount)
    {
        if (SkillPoint > 0)
        {
            STR += amount;
            SkillPoint--;
        }
    }

    public void InscreaseSPD(int amount)
    {
        if (SkillPoint > 0)
        {
            SPD += amount;
            SkillPoint--;
        }
    }

    public void InscreaseMP(int amount)
    {
        if (SkillPoint > 0)
        {
            MP += amount;
            SkillPoint--;
        }
    }

}
