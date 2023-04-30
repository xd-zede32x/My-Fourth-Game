using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cake", menuName = "Cake Item", order = 51)]
public class CakeShop : ScriptableObject
{
    [SerializeField] private Cake _cake;
    [SerializeField] private string _labue;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuy;

    public bool IsBuy => _isBuy;

    public string Label => _labue;
    public Cake Cake => _cake;
    public Sprite Icon => _icon;
    public int Price => _price;

    public int CakeProfit => _cake.Profit;

    public void Buy()
    {
        _isBuy = true;
    }

}
