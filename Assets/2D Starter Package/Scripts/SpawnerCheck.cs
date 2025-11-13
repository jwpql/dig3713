using System;
using UnityEngine;

// manages ui for getting items

namespace DigitalWorlds.StarterPackage2D
{
    public class SpawnerCheck : MonoBehaviour
    {
        //spawners for food 1, 2, 3 (IN THAT ORDER)
        public Spawner[] spawners;

        int numToSpawn = 0;

        public GameObject selectNum;
        public GameObject minigame;

        //player character (to enable/disable movement)
        public PlayerMovementTopDown player = null;

        void Start()
        {
            player = FindAnyObjectByType<PlayerMovementTopDown>();
            selectNum.SetActive(false);
            minigame.SetActive(false);
        }

        public void begin()
        {
            selectNum.SetActive(true);
            player.EnableMovement(false);
        }

        public void setItemToSpawn(int i)
        {
            numToSpawn = i;
            selectNum.SetActive(false);
            minigame.SetActive(true);
            OrderMinigame orderminigame = minigame.GetComponent<OrderMinigame>();
            orderminigame.startGame();
        }

        public void spawn()
        {
            spawners[numToSpawn-1].SpawnObject();
          
        }

        public void exit()
        {
            numToSpawn = 0;
            player.EnableMovement(true);
            minigame.SetActive(false);  
            selectNum.SetActive(false);
        }
    }
}