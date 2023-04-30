using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<CakeShop> _cakes;
    [SerializeField] private Player _player;
    [SerializeField] private Item _template;
    [SerializeField] private Transform _itemContrainer;


    private void Start()
    {
        for (int i = 0; i < _cakes.Count; i++)
        {
            AddItem(_cakes[i]);
        }
    }

    private void AddItem(CakeShop cakeItem)
    {
        Item item = Instantiate(_template, _itemContrainer);
        IntiallzeItem(item, cakeItem);
    }

    private void IntiallzeItem(Item item, CakeShop cakeItem)
    {
        item.SetCake(cakeItem);
        item.SellButtonClick += OnsellButtonClick;
        item.name = _template.name + (transform.childCount + 1);
    }

    private void OnsellButtonClick(CakeShop cakeItem, Item item)
    {
        TrySellCake(cakeItem , item);
    }

    private void TrySellCake(CakeShop cakeItem, Item item)
    {
        if (_player.CheckSolvense(cakeItem.Price))
        {
            _player.BuyCake(cakeItem);
            cakeItem.Buy();
            UnsubscriteItem(item);
        }
    }

    public void UnsubscriteItem(Item item)
    {

        item.SellButtonClick -= OnsellButtonClick;
    }
}