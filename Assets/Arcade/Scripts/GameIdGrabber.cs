using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcade
{
    public class GameIdGrabber : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Awake()
        {
            string gameId = "";
            string scene = SceneManager.GetActiveScene().name;
            gameId = scene.Split("_")[0];
            GameData.CurrentGameId = gameId;
        }
    }
#endif
}
