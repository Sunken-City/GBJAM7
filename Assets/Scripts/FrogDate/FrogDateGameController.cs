using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDateGameController : MonoBehaviour
{
    public GameObject dateCardPrefab;
    public GameObject loseObject;
    public GameObject winObject;
    public int numCards = 4;
    private int _currentCardIndex = 0;

    private GameObject[] _cards;
    // Start is called before the first frame update
    void Start()
    {
        _cards = new GameObject[numCards];
        _currentCardIndex = numCards - 1;

        for(int i = 0; i < numCards; ++i)
        {
            _cards[i] = Instantiate(dateCardPrefab, this.transform.position, this.transform.rotation, this.transform.parent);
        }

        _cards[Random.Range(0, numCards)].GetComponent<DateCard>().MakeOurBoy();
    }

    // Update is called once per frame
    void Update()
    {
        if(MicrogameController.instance.HasWon())
        {
            winObject.GetComponent<SpriteRenderer>().enabled = true;
            return;
        }
        else if(MicrogameController.instance.HasLost())
        {
            loseObject.GetComponent<SpriteRenderer>().enabled = true;
            return;
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            _cards[_currentCardIndex--].GetComponent<DateCard>().SwipeLeft();
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            _cards[_currentCardIndex--].GetComponent<DateCard>().SwipeRight();
        }
    }
}
