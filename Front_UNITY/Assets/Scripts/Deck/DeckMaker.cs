using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeckMaker : MonoBehaviour

{
    [SerializeField] List<StatUnit> unitList = new List<StatUnit>();
    [SerializeField] GameObject defaultCard;
    [SerializeField] Button backbutton;
    [SerializeField] Canvas canva;
    [SerializeField] float offset = 10f;
    [SerializeField] Deck deck;
    
    // Start is called before the first frame update
    void Awake()
    {
        backbutton.onClick.AddListener(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene", LoadSceneMode.Single); });
        var centerOfScreen = transform.position = new Vector3((float)Screen.width * 0.5f, (float)Screen.height * 0.5f, 0);
        var firstPos = (unitList.Count * offset) * 0.5f;
        //foreach (StatUnit unit in unitList)
        for ( int i = 0; i < unitList.Count; i++ )
        {
            var cardObject = Instantiate(defaultCard,centerOfScreen + (-firstPos + i*offset)*Vector3.right, Quaternion.identity, canva.transform);
            var card = cardObject.GetComponent<Card>();
            card.SetStats(unitList[i]);
            card.OnCardClicked.AddListener(delegate {

                deck.AddCard(card);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
