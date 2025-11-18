using TMPro;
using UnityEngine;

public class LvlEnd : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text profit;
    public TMP_Text guests;

    void Start()
    {
        int lvl = PlayerPrefs.GetInt("lastLevel") - 1;
        title.SetText("Day " + lvl.ToString() + " Complete!");
        int money = PlayerPrefs.GetInt("profit");
        profit.SetText(money.ToString());
        int guest = PlayerPrefs.GetInt("guests");
        guests.SetText(guest.ToString());
        PlayerPrefs.SetInt("profit", 0);
        PlayerPrefs.SetInt("guests", 0);
    }


}
