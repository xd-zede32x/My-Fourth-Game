using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CakePlace : MonoBehaviour
{
    [SerializeField] private clickerZone _clickerZone;
    [SerializeField] private CocingProgres _cocingProgres;
     private Cake _cake;

    public event UnityAction<Cake> CakeReadeForColection;

    public void SetCake(Cake cake)
    {
        _cake = Instantiate(cake, transform);
        _cake.CakeDone += OnCakeDone;
        _cake.LayerCoocingProgress += _cocingProgres.OnLayerCocungProgreses;
        _clickerZone.Click += _cake.OnClick;
    }

    public void RemoveCake(Cake cake)
    {
        _cake.CakeDone -= OnCakeDone;
        _cake.LayerCoocingProgress -= _cocingProgres.OnLayerCocungProgreses;
        _clickerZone.Click -= _cake.OnClick;
        Destroy(cake);
    }

    private void OnCakeDone()
    {
        CakeReadeForColection?.Invoke(_cake);
    }
}