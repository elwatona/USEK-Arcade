using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Clase nativa para la correcta carga de escenas
public class GameSceneManager
{
    //Método que carga una escena del juego actual. Los nombres de las esceneas siempre están en minúsculas
    //Llamar escribiendo: GameSceneManager.LoadScene(nombreEscena)
    /* sceneName: nombre de la escena.
     *      Los nombres disponibles son: menu, level1, level2, boss, bonus1, bonus2, intro, gameOver, end
     */
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene($"{GameData.CurrentGameId}_{sceneName}");
    }

    //Método que carga la escena de menú del juego actual
    //Llamar escribiendo: GameSceneManager.StartGame()
    public static void StartGame()
    {
        LoadScene("menu");
    }

    //Método que carga la siguiente escena del juego actual, cuando el jugador a superado una. En caso de ser la escena final, se regresa al menú
    //Llamar escribiendo: GameSceneManager.NextLevel()
    public static void NextLevel()
    {
        string nextScene = "";
        string currentScene = SceneManager.GetActiveScene().name;
        currentScene = currentScene.Split("_")[1];
        switch (currentScene)
        {
            case "menu": nextScene = "intro";
                break;
            case "intro": nextScene = "level1"; 
                break;
            case "level1": nextScene = "bonus1";
                break;
            case "bonus1": nextScene = "level2";
                break;
            case "level2": nextScene ="bonus2";
                break;
            case "bonus2": nextScene = "boss";
                break;
            case "boss": nextScene = "end";
                break;
            case "end": nextScene = "menu";
                break;
        }

        LoadScene(nextScene);
    }

    //Método que carga la escena de gameOver cuando el jugador pierde. Si se llama mientras se está en gameOver, se regresa al menú
    //Llamar escribiendo: GameSceneManager.GameOver()
    public static void GameOver()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        currentScene = currentScene.Split("_")[1];
        if (currentScene != "gameOver")
            LoadScene("gameOver");
        else
            LoadScene("menu");
    }
}