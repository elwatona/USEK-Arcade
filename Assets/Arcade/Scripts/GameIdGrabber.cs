using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade
{
    public class GameIdGrabber : MonoBehaviour
    {
        private void Awake()
        {
            string sceneType = "";
            string gameId = "";
            string scene = SceneManager.GetActiveScene().name;
            gameId = scene.Split("_")[0];

        #if !UNITY_EDITOR
            Debug.Log("TEST");
            sceneType = scene.Split("_")[1];
            if(sceneType == "menu")
        #endif
            GameData.CurrentGameId = gameId;
        }
    }
}
