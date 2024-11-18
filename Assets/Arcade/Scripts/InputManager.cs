using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Serializable]
    private class Player
    {
        [SerializeField] private UnityEvent<bool>[] _buttonEvents;
        [SerializeField] private UnityEvent<Vector2> _joystickEvent;
        private string _playerPrefix;
        private Vector2 _joystick => new Vector2(Input.GetAxis(_playerPrefix + "Horizontal"), Input.GetAxis(_playerPrefix + "Vertical"));

        public void SetPrefix(string value)
        {
            _playerPrefix = value;
        }

        private bool GetButton(int index)
        {
            switch (index)
            {
                case 0:
                    return Input.GetButton(_playerPrefix + "Fire1");
                case 1:
                    return Input.GetButton(_playerPrefix + "Fire2");
                default:
                    Debug.LogAssertion("El input ingresado no está registrado.");
                    return false;
            }
        }

        public void CheckButtons()
        {
            for (int i = 0; i < _buttonEvents.Length; i++)
            {
                _buttonEvents[i]?.Invoke(GetButton(i));
            }
        }

        public void CheckJoystick()
        {
            if (_joystick != Vector2.zero)
                _joystickEvent?.Invoke(_joystick);
        }
    }
    [SerializeField] private bool _canDebug;
    [SerializeField] private Player[] _players;
    private void OnEnable()
    {
        for (int i = 0; i < _players.Length; i++)
        {
            _players[i].SetPrefix($"P{i+1}_");
        }
    }
    private void Update()
    {
        foreach(Player player in _players)
        {
            player.CheckJoystick();
            player.CheckButtons();
        }
    }
    public void TestInput(Vector2 input)
    {
        if(_canDebug) Debug.Log(input);
    }
    public void TestInput(bool input)
    {
        if(_canDebug) Debug.Log(input);
    }
}
