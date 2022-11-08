using UnityEngine;

public enum TileType
{
    scorpio,
    medium,
    vase,
}
public class TileScript : MonoBehaviour
{
    [SerializeField] Sprite initialTile;
    [SerializeField] Sprite frontTile;
    [SerializeField] Sprite[] itemSprite;
    [SerializeField] Sprite excavatedTile;

    [SerializeField] GameObject itemGo;

    private SpriteRenderer myRenderer;
    public TileType myType;

    bool hasTouched = false;
    bool hasSeen = false;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = initialTile;
    }

    public void SetFrontTile()
    {
        if ( hasSeen == false && hasTouched == false)
        {
            hasSeen = true;
            myRenderer.sprite = frontTile;
        }
    }

    public void SetExcavatedTile()
    {
        if (hasTouched == false)
        {
            hasTouched = true;
            myRenderer.sprite = excavatedTile;
            if (itemSprite.Length > 0)
            {
                itemGo.GetComponent<SpriteRenderer>().sprite = itemSprite[Random.Range(0, itemSprite.Length)];
            }
            if ( myType == TileType.vase)
            {
                ExcavatorManager.instance.VaseFounded();
            }
            else if( myType == TileType.scorpio)
            {
                ExcavatorManager.instance.LoseLife();
            }
        }
    }


}
