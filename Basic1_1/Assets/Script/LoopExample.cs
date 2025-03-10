using UnityEngine;

public class LoopExample : MonoBehaviour
{
    void Start()
    {
        ////for¹®
        //for (int i = 1; i <= 10; i++)
        //    Debug.Log("Count : " + i);

        //while¹®
        int counter = 0;
        while (counter < 5)
        {
            Debug.Log("Count :" + counter);
            counter++;
        }
    }
}
