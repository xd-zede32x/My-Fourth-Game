using UnityEngine;
using UnityEngine.UI;

public class Clicer : MonoBehaviour
{
    private int Money;
    public Text Text;

    private void Start()
    {
        Text.text = Money.ToString();
        if (PlayerPrefs.HasKey ("Money"))
        {
            Money = PlayerPrefs.GetInt("Money");
        }
    }


    public void Click()
    {
        Money++;
        Text.text = Money.ToString();
        PlayerPrefs.SetInt("Money", Money);
    }
}
