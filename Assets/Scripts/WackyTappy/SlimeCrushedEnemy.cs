using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCrushedEnemy : MonoBehaviour
{

    public static int numOfSquishedSlimes;

    // Start is called before the first frame update
    void Start()
    {
        numberOfSquishedSlimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        while(numOfSquishedSlimes < 5)
        {
            if( ) //a slime is squished then add 1 to numOfSwishedSlimes
            {
                ++numOfSquishedSlimes; 
            }
            //being squished means that the finger circle collider collided with a slime collider
        }

        //when numOfSquishedSlimes = 5 the game is won
    }
}
