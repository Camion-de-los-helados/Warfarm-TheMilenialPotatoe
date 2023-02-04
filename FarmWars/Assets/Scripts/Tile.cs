using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color BaseColor, OffsetColor;
    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private GameObject Higlight;
    public float sizeX;
    public float sizeY;

    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    public void Init(bool isOffset)
    {
        Renderer.color = isOffset ? new Color(OffsetColor.r, OffsetColor.g, OffsetColor.b, 1f) : new Color(BaseColor.r, OffsetColor.g, OffsetColor.b, 1f);

        //Renderer.sortingLayerName = "Top";
        //Renderer.UpdateGIMaterials();
    }

    public Vector2 GetSizeofRenderer()
    {
        sizeX = Renderer.bounds.size.x;
        sizeY = Renderer.bounds.size.y;
        //Debug.Log(sizeX + " " + sizeY);
        return new Vector2(sizeX, sizeY);
    }
    void OnMouseEnter()
    {
        Higlight.SetActive(true);
    }

    void OnMouseExit()
    {
        Higlight.SetActive(false);
    }
}
