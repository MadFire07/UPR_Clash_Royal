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

                if (left != null && left.Team != bot.Team)
                    enemyBots.Add(left);
                if (right != null && right.Team != bot.Team)
                    enemyBots.Add(right);
                if (up != null && up.Team != bot.Team)
                    enemyBots.Add(up);
                if (down != null && down.Team != bot.Team)
                    enemyBots.Add(down);

                bot.Health -= enemyBots.Count;
                if (bot.Health <= 0) deadBots.Add(bot);
            }
            if(deadBots.Count > 0) setter.SetBots(deadBots);

        }
    }
}
