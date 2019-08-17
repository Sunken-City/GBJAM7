using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReaderObject : MonoBehaviour
{
    private BoxCollider2D boundingBox;
    public MoneyCounterObject moneyCounter;
    // Start is called before the first frame update
    void Start()
    {
        boundingBox = GetComponent<BoxCollider2D>();
        Debug.Assert(boundingBox, "This boy needs a bounding box!!");
        Debug.Assert(moneyCounter, "This boy needs his money counter!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(boundingBox.offset.x >= 0.2f)
        {
            boundingBox.offset = new Vector2(-0.2f, boundingBox.offset.y);
        }
        else
        {
            boundingBox.offset = new Vector2(0.2f, boundingBox.offset.y);
        }
        moneyCounter.ChargeCreditCard();
    }
}
