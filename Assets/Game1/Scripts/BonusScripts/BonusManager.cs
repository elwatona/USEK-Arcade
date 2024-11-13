using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BonusManager : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI scoreTextPlayer1, scoreTextPlayer2;
    public float timer;
    [SerializeField] private float _timeLimit;
    public float time;
    public bool isTimerOn = true;
    private int puntaje1, puntaje2;
    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        GanarPuntaje();
        TimerTime();
        
    }
    void GanarPuntaje()
    {
        //Los jugadores ganaran 1 punto por cada moviemiento completo realizado (izquierda a derecha || Arriba a Abajo)
      //player.transform += 1, MostrarPuntaje(); ??
        //Hacer un collider en un objeto invicible para que al chocar con el analogo del jugador puedan ganar puntos

    }
    void TimerTime()
    {
        if (!isTimerOn) return;
        //Hacer que espere 3 segundo antes de comenzar el bonus, el bonus tendra un total de 30 segundos.
        //Junto a la función TimerTime(), la funcion end y start bonus les dara la orden a cada uno.
        
        
        time = 0;
        timer += Time.deltaTime;
        if (timer>= _timeLimit)
        {
            isTimerOn = false;
            timer = 0;
        }
        textTime.text = "Timer: " + timer;
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
        scoreTextPlayer1.text = "Player 1:" + puntaje1;
        scoreTextPlayer2.text = "Player 2:" + puntaje2;
    }
    void EmpezarBonus()
    {
        //EmpezarElBonus.
    }
    void TerminarBonus()
    {
        //Acabar con el minijuego y cambiar escena en 3 seg;
    }
    
}
