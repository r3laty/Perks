using UnityEngine;

public class BoosterPicking : MonoBehaviour
{
    private Data _playerData;
    private void Awake()
    {
        _playerData = GetComponent<Data>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            other.TryGetComponent<ILevelUp>(out ILevelUp levelUpAction);
            if (levelUpAction is MonoBehaviour monobeh)
            {
                _playerData.PerksList.Add(monobeh);
            }
        }
    }
}
