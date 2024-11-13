using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerP2 : MonoBehaviour
{
    private BonusManager bM2;
    // Start is called before the first frame update
    void Start()
    {
        bM2 = GetComponent<BonusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        bM2.GanarPuntajeP2();
    }
}
