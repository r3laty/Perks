using UnityEngine;

public class AddDamage : MonoBehaviour, ILevelUp
{
    [SerializeField] private int howManyAddDamage = 10;
    public void LevelUp(Data data, int lvl)
    {
        data.Damage += howManyAddDamage;
        lvl++;
    }
}
