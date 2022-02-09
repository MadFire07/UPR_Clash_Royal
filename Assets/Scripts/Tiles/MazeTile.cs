using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTile : MonoBehaviour
{
    public enum TileTypes
    {
        Empty,
        Path,
        Wall,
        Mud,
        Trap,
        Start,
        End,
        Solution,
    }
    [Header("Design")]
    protected Sprite sprite;
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] protected Color color = new Color();
    [SerializeField] protected Color currentColor = new Color();
    [SerializeField] protected Color currentTeamColor = Color.clear;

    [Header("Infos")]
    protected TileTypes type = TileTypes.Empty;
    [SerializeField] protected int x;
    [SerializeField] protected int y;
    protected bool walkable = true;
    protected int speedModifier = 1;
    protected bool gameEnder = false;


    [Header("Pathfinding")]
    public int gCost;
    public int hCost;
    public int fCost;

    private void Start()
    {
        var col = gameObject.AddComponent<BoxCollider2D>();
        col.isTrigger = true;
        col.size = new Vector2(0.05f, 0.05f);
    }

    void OnMouseDown()
    {
        var userAction = FindObjectOfType<UserActions>();
        if (userAction.EndTile != this)
            FindObjectOfType<UserActions>().EndTile = this;
        else if (userAction.EndTile == this) userAction.MakeKnightMove();
    }
    


    public MazeTile previousStep;

    public Color CurrentColor { get => currentColor;
        set
        {
            currentColor = value;
            renderer.color = value;
        }
    }

    public Color CurrentTeamColor { get => currentTeamColor;
        set
        {
            renderer.color = value;
            currentTeamColor = value;
            currentColor = value;
        }
    }
    public void ReinitColor()
    {
            currentColor = Color.clear;
        if (currentTeamColor != Color.clear)
        {
            renderer.color = currentTeamColor;
        }
        else
            renderer.color = color;
    }

    public override string ToString()
    {
        return x + ", " + y;
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
    public int GetGCost()
    {
        return gCost;
    }
    public void SetGCost(int gCost)
    {
        Debug.Log("MazeTile, SetGCost : gCost = " + gCost);
        this.gCost = gCost;
    }
    public void SetRenderer()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public TileTypes GetTileType()
    {
        return type;
    }
    public void SetTileType(TileTypes type)
    {
        this.type = type;
    }
    public Color GetColor()
    {
        return color;
    }
    public void SetColor(Color color)
    {
        this.color = color;
        if (renderer == null) renderer.GetComponent<SpriteRenderer>();
        renderer.color = color;
    }
    public int GetXPos()
    {
        return x;
    }
    public void SetXPos(int x)
    {
        this.x = x;
    }
    public int GetYPos()
    {
        return y;
    }
    public void SetYPos(int y)
    {
        this.y = y;
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
    public void SetSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public bool GetWalkable()
    {
        return walkable;
    }
    public void SetWalkable(bool walkable)
    {
        this.walkable = walkable;
    }

    public int GetSpeedModifier()
    {
        return speedModifier;
    }
    public void SetSpeedModifier(int speedMd)
    {
        this.speedModifier = speedMd;
    }
    public bool GetGameEnder()
    {
        return gameEnder;
    }
    public void SetGameEnder(bool value)
    {
        this.gameEnder = value;
    }

    [System.Serializable]
    public class SaveObject
    {
        public TileTypes type;
        public int x;
        public int y;
    }

    public SaveObject Save()
    {
        return new SaveObject
        {
            type = type,
            x = x,
            y = y
        };
    }

}
