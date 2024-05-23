using UnityEngine;

public class AddWeapon : MonoBehaviour, ILevelUp
{
    [SerializeField] private int currentWeaponID = 2;
    public void LevelUp(Data data, int lvl)
    {
        data.WeaponID += currentWeaponID;
        lvl++;
    }
}
