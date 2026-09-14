using Game.Core;
using UnityEngine;

[CreateAssetMenu(fileName = "WinnersTextSo", menuName = "Scriptable Objects/WinnersTextSo")]
public class WinnersTextSo : ScriptableObject
{
    [SerializeField] private PlayerType _playerType;
    public PlayerType PlayerType => _playerType;

    [SerializeField] private string _playerText;
    public string PlayerText => _playerText;
}
