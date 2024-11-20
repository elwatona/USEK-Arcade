using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;

public class BonusManager : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI scoreTextPlayer1, scoreTextPlayer2, end, scoreP1, scoreP2;
    public float timer;
    [SerializeField] private float _timeLimit;
    public float time;
    private bool isTimerOn = true;
    private int puntaje1, puntaje2;
    private TriggerScript triggerScript;
    private TriggerP2 triggerP2;
    // Start is called before the first frame update
    void Start()
    {
        isTimerOn = true;
        triggerScript = GetComponent<TriggerScript>();
        triggerP2 = GetComponent<TriggerP2>();
    }

    // Update is called once per frame
    void Update()
    {
        
        TimerTime();
       
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
           
            end.text = "BONUS COMPLETE   PLAYER 1: " + triggerScript.scoreText.ToString() + "PLAYER 2: " + triggerP2.scoreText2.ToString(); //Not Set to an instance of an object. Que hacer?

            
            

        }
        textTime.text = "Timer: " + timer;
    }
   
    void MostrarPuntaje()
    {
        //El TextMeshPro debe mostrar el puntaje tanto del player 1 como del player 2;
        scoreTextPlayer1.text = "Player 1:" + scoreP1;
        scoreTextPlayer2.text = "Player 2:" + scoreP2;
    }
   
   

}
