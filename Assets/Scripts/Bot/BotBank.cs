using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBank : MazeBot
{
    [SerializeField] MazeMap map;
    private int it = 0;
    List<MazeTile> path; 

    // Start is called before the first frame update
    void Start()
    {
        SetCount(10);
        //Initialize();
        //path = pathfinding.FindPath(start[0], start[1], end[0], end[1]);
    }

    public void SetPath(MazeTile startTile, MazeTile endTile)
    {
        SetCount(0);
        Initialize(startTile.GetXPos(), startTile.GetYPos(), endTile.GetXPos(), endTile.GetYPos());
        path = pathfinding.FindPath(start[0], start[1], end[0], end[1]);
    }

    protected override void PickNextTile()
    {
        if (path == null) return;
        currentTile = path[it];
        currentTile.CurrentColor = Color.Lerp(spriteRenderer.color, Color.white, 0.5f);
        currentTile.CurrentTeamColor = Color.Lerp(spriteRenderer.color, Color.white, 0.5f);
        if (it != path.Count - 1) it++;

    }
    public override void Initialize()
    {
        base.Initialize();

        path = pathfinding.FindPath(start[0], start[1], end[0], end[1]);
        it = 0;
    }

}

