using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
     , IPointerClickHandler // 2
      /*IDragHandler
     , IPointerEnterHandler
     , IPointerExitHandler*/
{

    [SerializeField] protected StatUnit stats;
    public UnityEvent OnCardClicked = new UnityEvent();

    public StatUnit Stats { get => stats; set => stats = value; }

    // Start is called before the first frame update
    virtual public void UseCard(int x, int y)
    {
        Debug.Log("Card, UseCard : card used" + this.ToString());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetStats(StatUnit unit)
    {
        stats = unit;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        OnCardClicked.Invoke();
    }
}
