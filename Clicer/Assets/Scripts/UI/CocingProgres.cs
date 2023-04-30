using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocingProgres : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private float _finallySpeed;
    [SerializeField] private Color _unfilledColor;
    [SerializeField] private Color _finallyColor;

    private float _targetProgres;
    private Color _targetColor;

    public void ResetProgres()
    {
        _targetProgres = 0;
        _targetColor = _unfilledColor;
        _targetColor = _unfilledColor;
    }

    public void OnLayerCocungProgreses(float cookingProgres, float needdedValue)
    {
        _targetProgres = cookingProgres / needdedValue;
        _targetColor = Color.Lerp(_unfilledColor, _finallyColor, _targetProgres);
    }
    private void Update()
    {
        _slider.value = Mathf.Lerp(_slider.value, _targetProgres, _finallySpeed);
        _fill.color = Color.Lerp(_finallyColor, _targetColor, _finallySpeed);
    }
}
