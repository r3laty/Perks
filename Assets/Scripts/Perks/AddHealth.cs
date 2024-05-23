using UnityEngine;

public class AddHealth : MonoBehaviour, ILevelUp
{
    [SerializeField] private int howManyAddHealth = 10;
    public void LevelUp(Data data, int lvl)
    {
        data.Health += howManyAddHealth;
        lvl++;
    }
}
