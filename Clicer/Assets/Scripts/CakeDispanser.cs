using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeDispanser : MonoBehaviour
{
    [SerializeField] private CakeCollector _cakeCollector;
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private List<Cake> _cakeTemplates;
    [SerializeField] private Player _player; 

    private void OnEnable()
    {
        _cakeCollector.CakeCollected += OnCakeColacted;
        _player.CakeBouht += OnCakeBouth;
    }

    private void OnDisable()
    {
        _cakeCollector.CakeCollected -= OnCakeColacted;
        _player.CakeBouht -= OnCakeBouth;
    }

    private void Start()
    {
        DispanceCake();

    }

    private void DispanceCake()
    {
        int randomNumder = Random.Range(0, _cakeTemplates.Count);
        Cake randomCake = _cakeTemplates[randomNumder];
        _cakePlace.SetCake(randomCake);
    }

    private void OnCakeColacted(Cake cake)
    {
        _cakePlace.RemoveCake(cake);
        DispanceCake();
    }

    private void OnCakeBouth(Cake cake)
    {
        _cakeTemplates.Add(cake);
    }
}
