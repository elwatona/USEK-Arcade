using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BonusManager : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI scoreTextPlayer1, scoreTextPlayer2, end, scoreP1, scoreP2;
    public float timer;
    [SerializeField] private float _timeLimit;
    public float time;
    private bool isTimerOn = true;
    private int puntaje1, puntaje2;
    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        TimerTime();
        
    }
    public void GanarPuntajeP1()
    {
        scoreP1.text = " "+ 1;
        //Los jugadores ganaran 1 punto por cada moviemiento completo realizado (izquierda a derecha || Arriba a Abajo)
        //Hacer un collider en un objeto invicible para que al chocar con el analogo del jugador puedan ganar puntos
        //En el objeto vacio crear un script de OnTriggerEnter en donde el analogo del jugador llame al BonusManager GanarPuntos().
        //Implementar estructura de la funcion TimerTime().


    }
    public void GanarPuntajeP2()
    {
        scoreP2.text = " " + 1;
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
            end.text = "BONUS COMPLETE   PLAYER 1: " + puntaje1 + " PLAYER 2: " + puntaje2;
            
            

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
        scoreTextPlayer1.text = "Player 1:" + scoreP1;
        scoreTextPlayer2.text = "Player 2:" + puntaje2;
    }
    void EmpezarBonus()
    {
        //EmpezarElBonus.
        //Dejarlo al final.
    }
   
   

}
