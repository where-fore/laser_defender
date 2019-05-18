using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://books.google.ca/books?id=W8yPDwAAQBAJ&pg=PA63&lpg=PA63&dq=unity+singleton+parent&source=bl&ots=IFeaGDvRll&sig=ACfU3U2A9oWkEwdJeYuFZxDV5Rn0Cv5acQ&hl=en&sa=X&ved=2ahUKEwiMsrHbhaXiAhVSdt8KHYiIBdMQ6AEwCXoECAkQAQ#v=onepage&q=unity%20singleton%20parent&f=false

public class Singleton : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}