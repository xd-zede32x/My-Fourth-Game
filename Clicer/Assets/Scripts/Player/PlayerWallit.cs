using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallit : MonoBehaviour
{
    private int _bacedCake;
    public int BackedCake => _bacedCake;

    public event UnityAction<int> CakeBalansCharger;

    public void AddCakeProfit(int amount)
    {
        _bacedCake += amount;
        CakeBalansCharger?.Invoke(_bacedCake);
    }

    public void WithrawCake(int amount)
    {
        _bacedCake -= amount;
        CakeBalansCharger?.Invoke(_bacedCake);
    }
}

