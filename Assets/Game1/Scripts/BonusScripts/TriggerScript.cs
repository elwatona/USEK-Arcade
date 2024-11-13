using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private BonusManager bM;
    // Start is called before the first frame update
    void Start()
    {
        bM = GetComponent<BonusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {

        bM.GanarPuntajeP1();
    }
}
