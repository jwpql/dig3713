using UnityEngine;
using TMPro;

//tracks table occupancy, seats groups

namespace DigitalWorlds.StarterPackage2D
{
    public class TableManager : MonoBehaviour
    {
        public bool[] isOccupied;
        public Group waiting = null;
        public TMP_Text textArea = null;
        public AudioSource audioSource;
        public AudioClip enterSound;
        public AudioClip exitSound;
        public AudioClip interactSound;
        public TMP_Text moneyAdded = null;

        private void Start()
        {
            isOccupied = new bool[4] {false, false, false, false};
            textArea.canvasRenderer.SetAlpha(0);
            moneyAdded.canvasRenderer.SetAlpha(0);
        }
        public void seatAt(int table)
        {
            if(waiting == null)
            {
                return;
            }

            if (isOccupied[table - 1])
            {
                textArea.canvasRenderer.SetAlpha(1f);
                textArea.text = "Table is occupied.";
                textArea.CrossFadeAlpha(0, 3.0f, false);
                return;
            }

            bool successfullySeated = waiting.seatAt(table);
            if (successfullySeated)
            {
                isOccupied[table - 1] = true;
                waiting = null;
                playInteractSound();
            }
            
        }

        public bool hasValidTable(int size)
        {
            if (!isOccupied[3] || !isOccupied[2]) //if there is a big table free
            {
                return true;
            }
            if (size > 2)
            {
                textArea.canvasRenderer.SetAlpha(1f);
                textArea.text = "No available tables.";
                textArea.CrossFadeAlpha(0, 3.0f, false);
                return false;
            }
            if(!isOccupied[0] || !isOccupied[1]) //if there is a small table free
            {
                return true;
            }
            textArea.canvasRenderer.SetAlpha(1f);
            textArea.text = "No available tables.";
            textArea.CrossFadeAlpha(0, 3.0f, false);
            return false;
        }

        public void freeTable(int table)
        {
            isOccupied[table-1] = false;
        }

        public void playEnterSound()
        {
                audioSource.PlayOneShot(enterSound);
        }

        public void playExitSound()
        {
                audioSource.PlayOneShot(exitSound);
        }   

        public void playInteractSound()
        {
                audioSource.PlayOneShot(interactSound); 
        }   

        public void addMoney(int i)
        {
            if(moneyAdded == null) return;
            moneyAdded.text = "+" + i.ToString();
            moneyAdded.canvasRenderer.SetAlpha(1f);
            moneyAdded.CrossFadeAlpha(0, 4.0f, false);
        }
    }
}