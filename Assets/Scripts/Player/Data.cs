using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public List<MonoBehaviour> PerksList = new List<MonoBehaviour>();

    [HideInInspector] public int Damage = 0;
    [HideInInspector] public int Health = 0;
    [HideInInspector] public int WeaponID = 0;
    
    [SerializeField] private int score = 0;
    [SerializeField] private int lvl = 1;
    [SerializeField] private int scoreToNextLvl = 3;
    public void Score(int scoreAmount)
    {
        score += scoreAmount;
        if (score >= scoreToNextLvl && PerksList != null)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        print("LevelUp");
        scoreToNextLvl *= 2;
        foreach (var perk in PerksList)
        {
            if(perk is ILevelUp needed)
            {
                needed.LevelUp(this, lvl);
            }
        }
    }
}
