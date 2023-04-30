using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class CakeCollector : MonoBehaviour
{
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private Button _collectButton;

    private Cake _targetCake;
    private CanvasGroup _canvasGroup;

    public event UnityAction<Cake> CakeCollected;

    private void OnEnable()
    {
        _cakePlace.CakeReadeForColection += OnCakeRadyForColection;
        _collectButton.onClick.AddListener(CollectionCake);
    }

    private void OnDisable()
    {
        _cakePlace.CakeReadeForColection -= OnCakeRadyForColection;
        _collectButton.onClick.RemoveListener(CollectionCake);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Close();
    }

    private void OnCakeRadyForColection(Cake cake)
    {
        _targetCake = cake;
        Open();
    }

    private void CollectionCake()
    {
        CakeCollected?.Invoke(_targetCake);
        Close();
    }

    private void Open()
    {
        _canvasGroup.alpha = 1;
    }

    private void Close()
    {
        _canvasGroup.alpha = 0;
    }
}
