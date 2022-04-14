using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCard : Card
{
    [SerializeField] TMPro.TMP_Text statsLabel;
    [SerializeField] TMPro.TMP_Text nameLabel;
    [SerializeField] Image illustration;
    GameObject prefab;
    public override void UseCard(int x, int y)
    {
        base.UseCard(x, y);
        Instantiate(prefab,Vector3.zero,Quaternion.identity, null);//vector 3 wordposition x/y réelle position dans l'espace ||| null  = objet parent
    }
    // Start is called before the first frame update
    void Start()
    {
        statsLabel.text = stats.StatstoString();
        nameLabel.text = stats.name;
        illustration.sprite = stats.GetSprite();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
