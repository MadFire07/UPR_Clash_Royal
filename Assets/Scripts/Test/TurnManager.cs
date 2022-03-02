using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    [SerializeField] int turnNb = 0;
    [SerializeField] Button passTurn;
    [SerializeField] MapSetter setter;
    [SerializeField] MazeGrid grid;

    private void Awake()
    {
        setter = FindObjectOfType<MapSetter>();
        passTurn.onClick.AddListener(delegate { TurnNb++; });
    }
    private void Start()
    {

        grid = setter.Map.GetGrid();
    }
    public int TurnNb { get => turnNb;
        set
        {
            turnNb = value;
            
            var deadBots = new List<MazeBot>();
            foreach (MazeBot bot in setter.Bots)
            {
                var enemyBots = new List<MazeBot>();
                var left = setter.CheckBotOnATile(grid.GetValue(bot.CurrentTile.GetXPos() - 1, bot.CurrentTile.GetYPos()));
                var right = setter.CheckBotOnATile(grid.GetValue(bot.CurrentTile.GetXPos() + 1, bot.CurrentTile.GetYPos()));
                var up = setter.CheckBotOnATile(grid.GetValue(bot.CurrentTile.GetXPos(), bot.CurrentTile.GetYPos() + 1));
                var down = setter.CheckBotOnATile(grid.GetValue(bot.CurrentTile.GetXPos(), bot.CurrentTile.GetYPos() - 1));

                if (bot.Team == 0)
                {
                    if (up != null && up.Team != bot.Team)
                    {
                        up.Health -= 1;
                        if (up.Health <= 0) deadBots.Add(up);
                    } else if (left != null && left.Team != bot.Team)
                    {
                        left.Health -= 1;
                        if (left.Health <= 0) deadBots.Add(left);
                    } else if (right != null && right.Team != bot.Team)
                    {
                        right.Health -= 1;
                        if (right.Health <= 0) deadBots.Add(right);
                    } else if (down != null && down.Team != bot.Team)
                    {
                        down.Health -= 1;
                        if (down.Health <= 0) deadBots.Add(down);
                    }
                }
                else
                {
                    if (down != null && down.Team != bot.Team)
                    {
                        down.Health -= 1;
                        if (down.Health <= 0) deadBots.Add(down);
                    } else if (right != null && right.Team != bot.Team)
                    {
                        right.Health -= 1;
                        if (right.Health <= 0) deadBots.Add(right);
                    } else if (left != null && left.Team != bot.Team)
                    {
                        left.Health -= 1;
                        if (left.Health <= 0) deadBots.Add(left);
                    } else if (up != null && up.Team != bot.Team)
                    {
                        up.Health -= 1;
                        if (up.Health <= 0) deadBots.Add(up);
                    }
                }
            }
            if(deadBots.Count > 0) setter.SetBots(deadBots);

        }
    }
}
