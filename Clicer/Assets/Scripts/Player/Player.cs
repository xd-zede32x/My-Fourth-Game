using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerWallit))]
public class Player : MonoBehaviour
{

    [SerializeField] private CakeCollector _cakeCollector;
    private PlayerWallit _playerWallit;


    public event UnityAction<Cake> CakeBouht;

    private void OnEnable()
    {
        _cakeCollector.CakeCollected += OnCaceColected;
    }

    private void OnDisable()
    {
        _cakeCollector.CakeCollected -= OnCaceColected;
    }

    private void Start()
    {
        _playerWallit = GetComponent<PlayerWallit>();
    }

    private void OnCaceColected(Cake cake)
    {
        _playerWallit.AddCakeProfit(cake.Profit);
    }

    public bool CheckSolvense(int prise)
    {
        return _playerWallit.BackedCake >= prise;
    }

    public void BuyCake(CakeShop cakeItem)
    {
        _playerWallit.WithrawCake(cakeItem.Price);
        CakeBouht?.Invoke(cakeItem.Cake);
    }
}
