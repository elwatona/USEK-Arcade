using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusManager : MonoBehaviour
{
    public float x, y;
    public float spd;
    public TextMeshProUGUI textPoint;
    public float timer;
    public float time;
    public bool isTimerOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PalancaGiratoria()
    {
        //Hacer que los jgadores puedan mover la palanca de manera Horizontal o vertical
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical"); 
    }
    void GanarPuntaje()
    {
        //Los jugadores ganaran 1 punto por cada moviemiento completo realizado (izquierda a derecha || Arriba a Abajo)

    }
    void TimerTime()
    {
        //Hacer que espere 3 segundo antes de comenzar el bonus, el bonus tendra un total de 30 segundos.
        isTimerOn = true;
        time = 0;
        time += Time.deltaTime;
        if (time>= 30f)
        {
            isTimerOn = false;
            time = 0;
        }
    }
    void Orientacion(Vector2 Direccion)
    {
       //Que los jugadores muevan la palanca de manera horizontal o vertical dependiendo de lo que la orientacion pida
        {

        }
    }
}
