using System;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public static event Action<Item> Added;

    private Data _playerData;
    private void Awake()
    {
        _playerData = GetComponent<Data>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            if (other.TryGetComponent<ILevelUp>(out ILevelUp levelUpAction) && levelUpAction is MonoBehaviour monobeh)
            {
                if (!_playerData.PerksList.Contains(monobeh))
                {
                    _playerData.PerksList.Add(monobeh);
                }
            }

            if (other.TryGetComponent<Item>(out Item item))
            {
                print(item.name);
                Added?.Invoke(item);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            if (other.TryGetComponent<ILevelUp>(out ILevelUp levelUpAction) && levelUpAction is MonoBehaviour monobeh)
            {
                _playerData.PerksList.Remove(monobeh);
            }
            Destroy(other.gameObject);
        }
    }
}
