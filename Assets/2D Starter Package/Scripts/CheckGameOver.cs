using UnityEngine;
using System;

// if [targetCount] groups have been served, activate the button that lets you end the level and record last level completed

namespace DigitalWorlds.StarterPackage2D
{
    public class CheckGameOver : MonoBehaviour
    {
        public GameObject gameOverBtn;
        public int targetCount = 0;

        void Start()
        {
            gameOverBtn.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (CollectableManager.Instance == null)
            {
                Debug.LogWarning("CollectableManager not found!");
                return;
            }

            int c = CollectableManager.Instance.FindCollectable("GuestCount").count;
            if (c >= targetCount)
            {
                gameOverBtn.SetActive(true);
            }
        }

        public void setLastLevel(int i)
        {
            //keeps track of last level completed starting from tutorial (1)
            int money = CollectableManager.Instance.FindCollectable("Money").count;
            int guest = CollectableManager.Instance.FindCollectable("GuestCount").count;
            PlayerPrefs.SetInt("lastLevel", i);
            PlayerPrefs.SetInt("profit", money);
            PlayerPrefs.SetInt("guests", guest);
        }
    }
}
