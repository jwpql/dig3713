using UnityEngine;

// manages minigame for ordering items. player must press 4 keys in order
// IM GOATED

namespace DigitalWorlds.StarterPackage2D {
    public class OrderMinigame : MonoBehaviour
    {
        int numKeysPressed = 0;

        public KeyCode[] keystopress = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        KeyCode[] keys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        string[] text = {"W", "A", "S", "D" };

        //text showing what keys to press
        public TMPro.TMP_Text[] itemTexts;

        SpawnerCheck spawnerCheck;
        
        void Start()
        {
            spawnerCheck = FindAnyObjectByType<SpawnerCheck>();
        }

        public void startGame()
        {
            numKeysPressed = 0;
            for (int i = 0; i < 4; i++)
            {
                int rand = Random.Range(0, 4);
                keystopress[i] = keys[rand];
                itemTexts[i].text = text[rand];
                itemTexts[i].color = Color.black;
            }
        }

        void Update()
        {
            if (Input.anyKeyDown)
            {
                numKeysPressed++;
                if(numKeysPressed == 1)
                {
                    if (Input.GetKeyDown(keystopress[0]))
                    {
                        spawnerCheck.playSound(true);
                        itemTexts[0].color = Color.red;
                    }
                    else
                    {
                        spawnerCheck.playSound(false);
                        spawnerCheck.exit();
                    }
                }
                else if (numKeysPressed == 2)
                {
                    if (Input.GetKeyDown(keystopress[1]))
                    {
                        spawnerCheck.playSound(true);
                        itemTexts[1].color = Color.red;
                    }
                    else
                    {
                        spawnerCheck.playSound(false);
                        spawnerCheck.exit();
                    }
                }
                else if (numKeysPressed == 3)
                {
                    if (Input.GetKeyDown(keystopress[2]))
                    {
                        spawnerCheck.playSound(true);
                        itemTexts[2].color = Color.red;
                    }
                    else
                    {
                        spawnerCheck.playSound(false);
                        spawnerCheck.exit();
                    }
                }
                else if (numKeysPressed > 3)
                {
                    if (Input.GetKeyDown(keystopress[3]))
                    {
                        spawnerCheck.playSound(true);
                        Debug.Log("Correct Key 4");
                        spawnerCheck.spawn();
                    }
                    else
                    {
                        spawnerCheck.playSound(false);
                    }
                        spawnerCheck.exit();
                }
            }
        }
    }
}