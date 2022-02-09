using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEmpty : MazeTile
{
    // Start is called before the first frame update
    void Awake()
    {
        sprite = Resources.Load<Sprite>("Sprites/tile01");
        renderer = GetComponent<SpriteRenderer>();
        SetColor(color = Camera.main.backgroundColor);
        SetWalkable(false);

    }
}
