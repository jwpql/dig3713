using UnityEngine;
using TMPro;
namespace DigitalWorlds.StarterPackage2D
{
    public class TableManager : MonoBehaviour
    {
        public bool[] isOccupied;
        public Group waiting = null;
        public TMP_Text textArea = null;

        private void Start()
        {
            isOccupied = new bool[4] {false, false, false, false};
            textArea.canvasRenderer.SetAlpha(0);
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
    }
}