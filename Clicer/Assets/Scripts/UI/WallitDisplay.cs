using UnityEngine;
using UnityEngine.UI;

public class WallitDisplay : MonoBehaviour
{
    [SerializeField] private PlayerWallit _playerWallit;
    [SerializeField] private Text _cakeDispla;

    private void OnEnable()
    {
        _playerWallit.CakeBalansCharger += OncakeBalansCharger;
    }

    private void OnDisable()
    {
        _playerWallit.CakeBalansCharger -= OncakeBalansCharger;
    }

    private void OncakeBalansCharger(int cakeBalans)
    {
        _cakeDispla.text = cakeBalans.ToString();
    }

}
