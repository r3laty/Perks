using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public List<MonoBehaviour> PerksList = new List<MonoBehaviour>();

    /*[HideInInspector]*/ public int Damage = 0;
    /*[HideInInspector]*/ public int Health = 0;
    /*[HideInInspector]*/ public int WeaponID = 0;

    private int _score = 0;
    private int _lvl = 1;
    private int _scoreToNextLvl = 3;
    public void Score(int scoreAmount)
    {
        _score += scoreAmount;
        if (_score >= _scoreToNextLvl && PerksList != null)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        print("LevelUp");
        _scoreToNextLvl *= 2;
        foreach (var perk in PerksList)
        {
            if(perk is ILevelUp needed)
            {
                needed.LevelUp(this, _lvl);
            }
        }
    }
}
