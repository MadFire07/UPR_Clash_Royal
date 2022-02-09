using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MazeBot : MonoBehaviour
{
    private int COUNT = 20;
    protected int count = 1;
    [SerializeField] protected int team = 0;
    [SerializeField] protected bool canMove = false;
    [SerializeField] protected int health = 5;
    protected Pathfinding pathfinding;
    protected MazeGrid grid;
    protected Sprite sprite;
    protected SpriteRenderer spriteRenderer;
    [SerializeField] protected MazeTile currentTile;
    [SerializeField] protected int[] start;
    [SerializeField] protected int[] end;

    public MazeTile CurrentTile { get => currentTile; set => currentTile = value; }
    public int Health { get => health;
        set
        {
            health = value;
            if (health <= 0)
            {
                Destroy(gameObject, 0.05f);
            }
        }
    }
    public int Team { get => team; set => team = value; }

    void OnMouseDown()
    {
        FindObjectOfType<UserActions>().SelectedKnight = this;
    }
    private void Awake()
    {
        sprite = Resources.Load<Sprite>("Sprites/tile01");

        GameObject gameObject = new GameObject("visual", typeof(SpriteRenderer));
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 2;
        gameObject.transform.SetParent(transform);
        gameObject.transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one * 7f;

        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMove) return;
        count--;
        if (count == 0)
        {
            PickNextTile();
            SetSpeed();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, currentTile.transform.position, Mathf.Clamp(1f / (float)count, 0.02f, 0.08f));
        }
    }
    public void SetCanMove(bool value)
    {
        canMove = value;
    }
    // Start is called before the first frame update
    virtual public void Initialize()
    {
        //start = grid.FindStart();
        //end = grid.FindEnd();
        count = 1;
        var startTile = grid.GetValue(start[0], start[1]);
        transform.position = startTile.transform.position;
        currentTile = startTile;
        pathfinding = new Pathfinding(grid);
    }
    virtual public void Initialize(int x, int y)
    {
        count = 1;
        var startTile = grid.GetValue(x, y);
        transform.position = startTile.transform.position;
        currentTile = startTile;
        pathfinding = new Pathfinding(grid);


    }
    virtual public void Initialize(int x, int y, int endX, int endY)
    {
        count = 1;
        var startTile = grid.GetValue(x, y);
        transform.position = startTile.transform.position;
        currentTile = startTile;
        pathfinding = new Pathfinding(grid);


    }
    virtual public void SetStart(int x, int y)
    {

        start = new int[] { x , y };

    }
    virtual public void SetEnd(int x, int y)
    {

        end = new int[] { x, y };

    }
    protected void SetCount(int count)
    {
        COUNT = count;
    }
    protected int GetCount()
    {
        return COUNT;
    }

    public void SetGrid(MazeGrid grid)
    {
        this.grid = grid;
    }
    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    protected List<MazeTile> IsWalkable(List<MazeTile> list, MazeTile previousTile)
    {
        var outList = new List<MazeTile>();
        foreach (MazeTile tile in list)
        {
            if (tile.GetWalkable() && tile != previousTile) outList.Add(tile);
        }
        return outList;
    }
    protected void SetSpeed()
    {
        if (currentTile.GetTileType() == MazeTile.TileTypes.Trap
            || currentTile.GetTileType() == MazeTile.TileTypes.End) count = -1;
        else if (currentTile.GetTileType() == MazeTile.TileTypes.Mud) count = GetCount() * 2;
        else count = GetCount();
    }

    protected abstract void PickNextTile();
}
