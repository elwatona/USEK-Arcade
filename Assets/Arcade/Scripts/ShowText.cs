using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Clase que muestra un texto párrafo por párrafo
//Presionar cualquier tecla de ataque progresa el texto y cambia la escena al llegar al final
//utilizar 1 solo archivo de texto por escena
namespace Arcade
{
    public class ShowText : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textMesh;

        //Tiempo de espera entre cada letra mostrada
        //Definir en cada escena
        [SerializeField]
        private float _textDelay;

        //Archivo del texto que será reproducido en escena
        [SerializeField]
        private TextAsset _textFile;

        //Texto bruto. Puede definirse por inspector en caso que no se tenga archivo
        [SerializeField]
        [TextArea(7, 10)]
        private string _fullText;

        //Cáracter que define la separación de párrafos
        //Definir en cada escena por inspector
        //Se recomienda usar >
        [SerializeField]
        private string _lineSeparator = "";

        private string[] _lines;
        private int _lineIndex;
        private bool _showingTextLine;

        //Método que divide el texto en párrafos
        void ParseText()
        {
            //En caso que se tenga asignado un archivo de texto, se utiliza ese en vez de lo escrito en el inspector
            if (_textFile != null)
                _fullText = _textFile.text;
            //El texto se separa en "párrafos" separados por el caracter separador
            //El caracter separador NO se mostrará en pantalla
            _lines = _fullText.Split(_lineSeparator, System.StringSplitOptions.RemoveEmptyEntries);
            _lineIndex = 0;
        }

        //Corrutina que muestra 1 párrafo de texto caracter por caracter hasta llegar al fin del párrafo
        //Modificar _textDelay para cambiar velocidad
        IEnumerator DisplayTextLine()
        {
            if (_lineIndex < _lines.Length)
            {
                _showingTextLine = true;
                int charIndex = 0;
                _textMesh.text = _lines[_lineIndex];

                while (charIndex < _lines[_lineIndex].Length)
                {
                    charIndex++;
                    _textMesh.maxVisibleCharacters = charIndex;
                    yield return new WaitForSeconds(_textDelay);
                }
            }
            _showingTextLine = false;
        }

        //Método que muestra inmediatamente el párrafo, sin la animación de la corrutina
        void ShowFullLine()
        {
            if (_showingTextLine)
            {
                StopAllCoroutines();
                _textMesh.maxVisibleCharacters = _lines[_lineIndex].Length;
                _showingTextLine = false;
            }
        }


        //Método que muestra el siguiente párrafo si ya se terminó de mostrar uno
        //En caso contrario, llama ShowFullLine(), salta la animación del texto y muestra el párrafo inmediatamente
        //En caso que sea la línea final, cambia de escena
        void ShowNextLine()
        {
            if (_lineIndex >= _lines.Length -1)
            {
                SkipToNextScene();
            }
            else if (!_showingTextLine)
            {
                _lineIndex++;
                StartCoroutine(DisplayTextLine());
            }
            else
            {
                ShowFullLine();
            }
        }

        //Método que cambia a la siguiente escena en caso que se haya terminado de mostrar el´párrafo actual
        void SkipToNextScene()
        {
            if (!_showingTextLine)
            {
                GameSceneManager.NextLevel();
            }
            else
            {
                ShowFullLine();
            }
        }

        private void Awake()
        {
            ParseText();
        }
        private void Start()
        {
            StartCoroutine(DisplayTextLine());
        }


        private void Update()
        {
            if (Input.GetButtonDown("P1_Fire1") ||  Input.GetButtonDown("P2_Fire1") || Input.GetButtonDown("P1_Fire2") || Input.GetButtonDown("P2_Fire2"))
            {
                ShowNextLine();
            }
        }
    }
}