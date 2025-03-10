using UnityEngine;

public class LoopExample : MonoBehaviour
{
    void Start()
    {
        ////for문
        //for (int i = 1; i <= 10; i++)
        //    Debug.Log("Count : " + i);

        //while문
        int counter = 0;
        while (counter < 5)
        {
            Debug.Log("Count :" + counter);
            counter++;
        }
    }
}
