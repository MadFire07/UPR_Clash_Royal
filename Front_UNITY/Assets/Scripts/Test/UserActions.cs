using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserActions : MonoBehaviour
{
    [SerializeField] MazeBot selectedKnight;
    [SerializeField] MazeTile startTile;
    [SerializeField] MazeTile endTile;
    [SerializeField] MapSetter setter;
    [SerializeField] List<MazeTile> solution = new List<MazeTile>();

    public MazeBot SelectedKnight { get => selectedKnight; 
        set
            {
            selectedKnight = value;
            startTile = selectedKnight.CurrentTile;
            endTile = null;
            CleanUpSolution();
            solution.Clear();
        } 
    }
    public MazeTile EndTile { get => endTile;
        set
        {
            var bot = setter.CheckBotOnATile(value);

            if (bot != null)
            {

                selectedKnight = bot;
                startTile = selectedKnight.CurrentTile;
                endTile = null;
                CleanUpSolution();
                solution.Clear();
            }
            else
            {
                endTile = value;
                CleanUpSolution();
                if (endTile != null && selectedKnight != null) solution = setter.CheckPathfinding(startTile, endTile);
                if (solution.Count > 0)
                    GreeUpTheSolution(solution);
            }
        }
    }

    public void MakeKnightMove()
    {
        if (endTile != null && selectedKnight != null && solution.Count > 0)
        {
            selectedKnight.SetEnd(endTile.GetXPos(), endTile.GetYPos());
            selectedKnight.SetStart(selectedKnight.CurrentTile.GetXPos(), selectedKnight.CurrentTile.GetYPos());
            selectedKnight.Initialize();
            selectedKnight.SetCanMove(true);


            CleanUpSolution();
            solution.Clear();

            startTile = endTile;

        }

    }

    private void CleanUpSolution()
    {
        foreach (MazeTile tile in solution)
        {
            tile.ReinitColor();
        }
    }

    private void GreeUpTheSolution(List<MazeTile> solution)
    {
        foreach(MazeTile tile in solution)
        {
            tile.CurrentColor = Color.green;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        setter = FindObjectOfType<MapSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
