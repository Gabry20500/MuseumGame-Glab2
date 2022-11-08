using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] Sprite initialTile;
    [SerializeField] Sprite frontTile;
    [SerializeField] Sprite[] itemSprite;
    [SerializeField] Sprite excavatedTile;

    [SerializeField] GameObject itemGo;

    private SpriteRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = initialTile;
    }

    public void SetFrontTile()
    {
        myRenderer.sprite = frontTile;
    }

    public void SetExcavatedTile()
    {
        myRenderer.sprite = excavatedTile;
        if(itemSprite.Length > 0)
        {
            itemGo.GetComponent<SpriteRenderer>().sprite = itemSprite[Random.Range(0, itemSprite.Length)];
        }
    }
}
