using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoButton : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Button _openDutton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _openDutton.onClick.AddListener(OpenShop);
        _closeButton.onClick.AddListener(CloseShop);
    }

    private void OnDisable()
    {
        _openDutton.onClick.RemoveListener(OpenShop);
        _closeButton.onClick.RemoveListener(CloseShop);
    }

    public void OpenShop()
    {
        _shop.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        _shop.gameObject.SetActive(false);
    }

}
