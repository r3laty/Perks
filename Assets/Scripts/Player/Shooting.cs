using System.Threading.Tasks;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int scoreAmount = 1;

    private Data _playerData;
    private bool _isShooting;
    private void Awake()
    {
        _playerData = GetComponent<Data>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_isShooting)
        {
            _playerData.Score(scoreAmount);
            print("Shot!");
            _isShooting = true;
            Recharge();
        }    
    }
    private async void Recharge()
    {
        await Task.Delay(1000);
        _isShooting = false;
    }
}
