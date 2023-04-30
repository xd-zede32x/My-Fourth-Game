using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _profit;

    private CakeLeft[] _layers;
    private int _createdLayers;

    public int Profit => _profit;
    public bool Done => _createdLayers == _layers.Length;

    public event UnityAction CakeDone;

    public event UnityAction<float, float> LayerCoocingProgress;

    private void Start()
    {
        _layers = GetComponentsInChildren<CakeLeft>();

        _createdLayers = 0;
    }

    public void OnClick()
    {
        if (Done == false)
        {
            if (TryBakeLayer())
            {
                if (Done == true)
                {
                    CakeDone?.Invoke();
                }
            }
        }
    }

    private bool TryBakeLayer()
    {
        CakeLeft cakeLeft = _layers[_createdLayers];

        cakeLeft.IncreaceCockingProgress();
        LayerCoocingProgress?.Invoke(cakeLeft.Cokingprogress, cakeLeft.ClickBeforeCoking);

        if (cakeLeft.TryCokLayer())
        {
            _createdLayers++;
            return true;
        }
        else
        {
            return false;
        }
    }
}