using UnityEngine;

public class LvlSelectBG : MonoBehaviour
{
    public Sprite[] sprites;
    void Start()
    {
        int lastLevel = PlayerPrefs.GetInt("lastLevel");
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(sprites.Length > lastLevel)
        {
            spriteRenderer.sprite = sprites[lastLevel];
         }
    }

}
