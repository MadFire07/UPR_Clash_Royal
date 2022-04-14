using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckMakerInput : MonoBehaviour
{
    [SerializeField] Deck deck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clique pétasse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage
                if (hit.transform.name == "CardPrefab") {
                    deck.AddCard(hit.transform.GetComponent<Card>());
                // SceneManager.LoadScene("SceneTwo");
            }
        }*/
    }


}
