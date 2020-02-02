using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KugUtil : MonoBehaviour
{
    public static KugUtil Instance;
    [SerializeField] public GameObject GemBaby;
    [SerializeField] public GameObject[] shipParts;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    
}
