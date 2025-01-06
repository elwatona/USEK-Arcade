using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuControls : MonoBehaviour
{
    public void BeginGame() 
    {
        GameSceneManager.NextLevel();
    }

    public void BackToArcadeMenu() 
    { 
        GameSceneManager.ExitGame();
    }
}
