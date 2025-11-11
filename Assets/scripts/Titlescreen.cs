using UnityEngine;

public class Titlescreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("lastLevel", 0);
    }

}
