using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    private float rigFactor;

    void Start()
    {
        rigFactor = GameObject.FindGameObjectWithTag("DataStorage").GetComponent<DataStorage>().rigFactor;
    }

    private void Caclulation()
    {
        float chance = Random.Range(1.0f, rigFactor);
    }   
}
