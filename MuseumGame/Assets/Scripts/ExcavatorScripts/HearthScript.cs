using UnityEngine;

public class HearthScript : MonoBehaviour
{
    [SerializeField] Sprite emptySprite;
    bool changed = false;
    public void ChangeSprite()
    {
        SpriteRenderer _spriteRenderer = GetComponent<SpriteRenderer>();
        if(_spriteRenderer != null && changed == false) 
        {
            changed = true;
            _spriteRenderer.sprite = emptySprite;
        }
    }
}
