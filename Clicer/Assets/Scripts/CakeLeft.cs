using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class CakeLeft : MonoBehaviour
{
    [SerializeField] private int _clickBeforeCoking;

    private SpriteRenderer _spriteRenderer;
    private Color _layerColor;

    public int Cokingprogress { get; private set; }
    public int ClickBeforeCoking => _clickBeforeCoking;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _layerColor = _spriteRenderer.color;
        CreateGostLayer();
    }

    public void IncreaceCockingProgress()
    {
        Cokingprogress++;
    }

    private void CreateGostLayer()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 60);
    }

    public bool TryCokLayer()
    {
        if (_clickBeforeCoking == Cokingprogress)
        {
            _spriteRenderer.color = _layerColor;
            return true;
        }
        else
        {
            return false;
        }
    }
}
