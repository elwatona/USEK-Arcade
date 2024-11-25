using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Serializable]
    private class Player
    {
        [Serializable]
        private struct ButtonEvent
        {
            [SerializeField] private bool _continuousCallback;
            [SerializeField] private UnityEvent<bool> _event;
            public bool ContinuousCallback => _continuousCallback;
            public UnityEvent<bool> Event => _event;
        }
        [SerializeField] private ButtonEvent[] _buttonEvents;
        [SerializeField] private UnityEvent<Vector2> _joystickEvent;
        private string _playerPrefix;
        private Vector2 _joystick => new Vector2(Input.GetAxis(_playerPrefix + "Horizontal"), Input.GetAxis(_playerPrefix + "Vertical"));

        public void SetPrefix(string value)
        {
            _playerPrefix = value;
        }

        private bool GetButton(int index, bool continuous)
        {
            string action = _playerPrefix;
            switch (index)
            {
                case 0:
                    action += "Fire1";
                    break;
                case 1:
                    action += "Fire2";
                    break;
                default:
                    Debug.LogAssertion("El input ingresado no está registrado.");
                    return false;
            }
            return continuous ? Input.GetButton(action) : Input.GetButtonDown(action);
        }

        public void CheckButtons()
        {
            for (int i = 0; i < _buttonEvents.Length; i++)
            {
                ButtonEvent buttonEvent = _buttonEvents[i];
                buttonEvent.Event?.Invoke(GetButton(i, buttonEvent.ContinuousCallback));
            }
        }

        public void CheckJoystick()
        {
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
