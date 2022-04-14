using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List <Card> deck = new List<Card>();
    [SerializeField] GameObject defaultCard;
    [SerializeField] float offset = 10f;
    [SerializeField] Canvas canva;
    private float maxCard = 10;
    public void AddCard(Card  card)
    {
        // var centerOfScreen = transform.position = new Vector3((float)Screen.width * 0.5f, (float)Screen.height * 0.5f, 0);
        // var firstPos = (unitList.Count * offset) * 0.5f;
        if(deck.Count == maxCard)
        {
            return;
        }
        deck.Add(card);
        var cardObject = Instantiate(defaultCard,(deck.Count-1) * offset * Vector3.right, Quaternion.identity, canva.transform);
        var cardComponent = cardObject.GetComponent<Card>();
        cardComponent.SetStats(card.Stats);
        // cardObject.transform.localScale /= 2f;
        var Rekt = cardObject.GetComponent<RectTransform>();
        cardObject.transform.position += Rekt.rect.height * 0.5f * Vector3.up;
        cardObject.transform.position += Rekt.rect.width * 0.5f * Vector3.right;
        //Rekt.localPosition += cardObject.transform.localScale.y *0.5f * Vector3.up;
        cardComponent.OnCardClicked.AddListener(delegate {
            RemoveCard(deck.Count - 1);
        });
    }

    private void RemoveCard(int cardComponent)
    {
        deck.RemoveAt(cardComponent);
    }

    public void UseCard(Card card)
    {
        //
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
