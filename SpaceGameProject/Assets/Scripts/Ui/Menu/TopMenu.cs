using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TopMenu : MonoBehaviour
{
    [Header("Top")]
    [SerializeField] private PlayerTop _playerTop;
    [SerializeField] private PlayerInfoVisualization _playerInfoVisualization;
    [SerializeField] private Transform _container;

    private List<PlayerInfoVisualization> _visualizations = new List<PlayerInfoVisualization>();

    public void OnEnable()
    {
        Visualize();
    }

    public void Init(PlayerTop playerTop)
    {
        _playerTop = playerTop;
    }

    private void Visualize()
    {
        DeVisualize();

        uint topIndex = 1;

        foreach (var player in _playerTop.GetTop())
        {
            var newVisualizetion = Instantiate(_playerInfoVisualization, _container);

            newVisualizetion.Visualize(player, topIndex);

            _visualizations.Add(newVisualizetion);

            topIndex++;
        }
    }

    private void DeVisualize()
    {
        foreach (var visualization in _visualizations)
        {
            Destroy(visualization.gameObject);
        }

        _visualizations.Clear();
    }

    [System.Serializable]
    public class PlayerTop
    {
        [SerializeField] private List<PlayerInfo> _players;

        public PlayerTop(IEnumerable<PlayerInfo> players)
        {
            _players = players.ToList();
        }

        public IEnumerable<PlayerInfo> GetTop()
        {
            return _players.OrderByDescending(player => player.Money);
        }
    }

    [System.Serializable]
    public struct PlayerInfo
    {
        [SerializeField] private string _username;

        [SerializeField] private uint _money;

        public string Username => _username;

        public int Money => (int)_money;

        public PlayerInfo(string username, uint money)
        {
            _username = username;
            _money = money;
        }
    }
}
