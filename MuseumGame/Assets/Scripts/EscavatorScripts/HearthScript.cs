using UnityEngine;

public class HearthScript : MonoBehaviour
{
    [SerializeField] Sprite emptySprite;
    public void ChangeSprite()
    {
        SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();
        if(_spriteRenderer != null)
        {
            _spriteRenderer.sprite = emptySprite;
        }
    }
}
