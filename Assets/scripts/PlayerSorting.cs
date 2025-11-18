using UnityEngine;

public class PlayerSorting : MonoBehaviour
{
    public Renderer playerRenderer;


    void LateUpdate()
    {
        playerRenderer.sortingOrder = -(int)(GetComponent<Collider2D>().bounds.min.y * 1000);
    }
}
