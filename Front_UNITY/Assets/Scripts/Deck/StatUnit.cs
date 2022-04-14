using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class StatUnit : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] int healthPoint;
    [SerializeField] int maxHealth;
    [SerializeField] int moovementPoint;
    [SerializeField] Sprite illustration;
    public string StatstoString()
    {
        var statsReturn = "health : " + healthPoint + "\nmax Health : " + maxHealth + "\nspeed : " + moovementPoint;
        Debug.Log(statsReturn);
        return statsReturn;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal Sprite GetSprite()
    {
        return illustration;
    }
}
