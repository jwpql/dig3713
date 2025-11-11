using UnityEngine;

public class TutorialStuff : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textDisplay;
    public GameObject panel;
    void OnTriggerEnter2D(Collider2D other)
    {
        textDisplay.enabled = true;
        panel.SetActive(true);
        textDisplay.text = "Press 1, 2, or 3 to get items.";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textDisplay.enabled = false;
        panel.SetActive(false);
    }
}
