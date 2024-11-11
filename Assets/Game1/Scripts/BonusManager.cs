using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusManager : MonoBehaviour
{
    private float x, y;
    public float spd;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI text;
    public float timer;
    public float time;
    public bool isTimerOn = true;
    public int puntaje1, puntaje2;
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
        Vector3 dir = new Vector3(x, y,0);
        transform.position += dir;
        // Vector3.right;
        //Vector3.left;
        //Vector3.up;
        //Vector3.down;
    }
    void GanarPuntaje()
    {
        //Los jugadores ganaran 1 punto por cada moviemiento completo realizado (izquierda a derecha || Arriba a Abajo)
        bool playerPoint1 = false;
        bool playerPoint2 = false;
        while(playerPoint1 == true)
        {
            puntaje1 = 0;
            puntaje1++;
        }
        while (playerPoint2 == true)
        {
            puntaje2 = 0;
            puntaje2++;
        }
        

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
            
            
                //changeOrientation cambia la direccion en la que el jugador bombea o mueve la palanca en horizontal o vertical
                //Vector3.right += puntaje1;
               
            
            

        }
    }
    void MostrarPuntaje()
    {
        //El TextMeshPro debe mostrar el puntaje tanto del player 1 como del player 2;
    }
    void EmpezarBonus()
    {

    }
    void TerminarBonus()
    {

    }
}
