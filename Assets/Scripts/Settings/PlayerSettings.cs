using System;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using Game.Player;
using Game.Data;

namespace Game.Settings
{
    //IMPORTANTE: pasar el rotation amount a scriptable object. Pasar también a scriptable
    //object si es jugador 1 o 2

    //REFACTORIZAR CON GENERICS Y CON SCRIPTABLE OBJECTS (LA INFO DEL JUGADOR VA A IR EN SCRIPTABLEOBJECTS)
    //CREO QUE YA ESTA TODO EN SCRIPTABLE EN INTIALSETTINGS

    public class PlayerSettings : MonoBehaviour
    {
        private static PlayerSettings _instance;

        [SerializeField] private PlayerInitialSettingsSo _initialSettings;

        private Dictionary<PlayerType, float> _movementSpeeds;

        private Dictionary<PlayerType, Color32> _colors;

        private Dictionary<PlayerType, float> _yScales;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                return;
            }

            _movementSpeeds = new Dictionary<PlayerType, float>();

            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                _movementSpeeds.Add(playerType, _initialSettings.MovementSpeed);
            }

            _colors = new Dictionary<PlayerType, Color32>();

            foreach (PlayerType playerType in Enum.GetValues(typeof(PlayerType)))
            {
                _colors.Add(playerType, _initialSettings.PadColor);
            }

            _yScales = new Dictionary<PlayerType, float>();

            foreach(PlayerType playerType in Enum.GetValues(typeof (PlayerType)))
            {
                _yScales.Add(playerType, _initialSettings.PadSize);
            }

            PlayerEvents.OnPlayerInitialized += SendPlayerMovementSpeed;
            PlayerEvents.OnPlayerInitialized += SendPlayerScale;

            PlayerEvents.OnPlayerMovementSpeedChangeRequested += UpdateSpeedValues;
            PlayerEvents.OnPlayerColorChangeRequested += UpdateColorValues;
            PlayerEvents.OnPlayerSizeChangeRequested += UpdateScaleValues;

            UIEvents.OnSpeedSliderInitialValueRequested += SendUISpeedValue;
            UIEvents.OnColorInitialValueRequested += SendUIColorValue;
            UIEvents.OnSizeSliderInitialValueRequested += SendUIScaleValue;
        }

        private void OnDestroy()
        {
            PlayerEvents.OnPlayerInitialized -= SendPlayerMovementSpeed;
            PlayerEvents.OnPlayerInitialized -= SendPlayerScale;

            PlayerEvents.OnPlayerMovementSpeedChangeRequested -= UpdateSpeedValues;
            PlayerEvents.OnPlayerColorChangeRequested -= UpdateColorValues;
            PlayerEvents.OnPlayerSizeChangeRequested -= UpdateScaleValues;

            UIEvents.OnSpeedSliderInitialValueRequested -= SendUISpeedValue;
            UIEvents.OnColorInitialValueRequested -= SendUIColorValue;
            UIEvents.OnSizeSliderInitialValueRequested -= SendUIScaleValue;

            if (_instance == this)
            {
                _instance = null;
            }
        }

        private void UpdateSpeedValues(PlayerType playerType, float speed)
        {
            _movementSpeeds[playerType] = speed;
            SendPlayerMovementSpeed(playerType);
        }

        private void SendPlayerMovementSpeed(PlayerType playerType)
        {
            PlayerEvents.RaisePlayerMovementSpeedUpdated(playerType, _movementSpeeds[playerType]);           
        }

        private void SendUISpeedValue(PlayerType playerType)
        {
            UIEvents.RaiseSpeedSliderValueInitialized(playerType, _movementSpeeds[playerType]);
        }

        private void UpdateColorValues(PlayerType playerType, Color32 color)
        {
            _colors[playerType] = color;
            SendPlayerColor(playerType);
        }

        private void SendPlayerColor(PlayerType playerType)
        {
            PlayerEvents.RaisePlayerColorUpdatedInSettings(playerType, _colors[playerType]);
        }

        private void SendUIColorValue(PlayerType playerType)
        {
            UIEvents.RaiseColorValueInitialized(playerType, _colors[playerType]);
        }

        private void UpdateScaleValues(PlayerType playerType, float yScale)
        {
            _yScales[playerType] = yScale;
            SendPlayerScale(playerType);
        }

        private void SendPlayerScale(PlayerType playerType)
        {
            PlayerEvents.RaisePlayerSizeUpdated(playerType, _yScales[playerType]);
        }

        private void SendUIScaleValue(PlayerType playerType)
        {
            UIEvents.RaiseSizeValueInitialized(playerType, _yScales[playerType]);
        }
    }
}


