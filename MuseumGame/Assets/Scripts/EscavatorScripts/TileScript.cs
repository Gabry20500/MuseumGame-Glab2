using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] Sprite initialTile;
    [SerializeField] Sprite frontTile;
    [SerializeField] Sprite item;
    [SerializeField] Sprite excavatedTile;

    private SpriteRenderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = initialTile;
    }
}
