using UnityEngine;
using System;

namespace DigitalWorlds.StarterPackage2D
{
    public class CheckGameOver : MonoBehaviour
    {
        public GameObject gameOverBtn;
        public string collectableName = "Guests";
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

            int c = CollectableManager.Instance.FindCollectable(collectableName).count;
            if (c >= targetCount)
            {
                gameOverBtn.SetActive(true);
            }
        }

        public void setLastLevel(int i)
        {
            //keeps track of last level completed starting from tutorial (1)
            PlayerPrefs.SetInt("lastLevel", i);
        }
    }
}
