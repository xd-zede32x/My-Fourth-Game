using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Text _labue;
    [SerializeField] private Text _price;
    [SerializeField] private Text _profit;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _seallButton;

    private CakeShop _cakeItem;


    public event UnityAction<CakeShop, Item> SellButtonClick;

    private void OnEnable()
    {
        _seallButton.onClick.AddListener(OnSellButtonClick);
        _seallButton.onClick.AddListener(CheckCakeState);
    }

    private void OnDisable()
    {
        _seallButton.onClick.RemoveListener(OnSellButtonClick);
        _seallButton.onClick.RemoveListener(CheckCakeState);
    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_cakeItem, this);
    }

    private void CheckCakeState()
    {
        if (_cakeItem.IsBuy)
        {
            _seallButton.interactable = false;
            _labue.text = "Продано!";

        }
    }
    public void SetCake(CakeShop cakeShop)
    {
        _cakeItem = cakeShop;
        RenderCake(_cakeItem);
    }

    private void RenderCake(CakeShop cakeShop)
    {
        _labue.text = _cakeItem.Label;
        _price.text = _cakeItem.Price.ToString();
        _profit.text = _cakeItem.CakeProfit.ToString();
        _icon.sprite = _cakeItem.Icon;



    }
}
