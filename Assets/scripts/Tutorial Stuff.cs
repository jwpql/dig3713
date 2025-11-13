using Unity.Burst.CompilerServices;
using UnityEngine;

//random tutorial exclusive functinality
public class TutorialStuff : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textDisplay;
    public GameObject panel;

    //hint text when player approaches door
    void OnTriggerEnter2D(Collider2D other)
    {
        textDisplay.enabled = true;
        panel.SetActive(true);
        textDisplay.text = "Press F to tell the kitchen what you need.";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textDisplay.enabled = false;
        panel.SetActive(false);
    }
}
