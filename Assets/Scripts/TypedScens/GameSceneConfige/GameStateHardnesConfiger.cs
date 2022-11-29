using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateHardnesConfiger : GameSceneLoadEvent
{
    [SerializeField] private MetorSpawnByTime _meteorSpawnByTime;
    [SerializeField] private UFloat _meteorHardnesModiffier;
    [Header("Boss Sellector")]
    [SerializeField] private GameState _globalGameState;
    [SerializeField] private WinCondition _standartWinCondution;
    [SerializeField] private WinPastDie _bossWinCondution;
    [SerializeField] private TransiterToBossPastTime _goToBossPastTime;

    [SerializeField] private List<BossSellectCondution> _bossSellectCondutions;

    private void OnValidate()
    {
        OrderBosses();
    }

    public override void OnSceneLoaded(GameSceneArguments argument)
    {
        _meteorSpawnByTime.StartSpawn(_meteorHardnesModiffier * Mathf.Sqrt(argument.HardnesLevel + 1));

        SellectBoss(argument.HardnesLevel);
    }

    private void SellectBoss(uint hardnes)
    {
        OrderBosses();

        if (_bossSellectCondutions.Count <= 0 || _bossSellectCondutions.First().ScoreToSellect > hardnes)
        {
            _globalGameState.Init(_standartWinCondution);
        }

        int currentBossIndex = 0;

        while (_bossSellectCondutions[currentBossIndex].ScoreToSellect > hardnes && currentBossIndex + 1 < _bossSellectCondutions.Count)
        {
            currentBossIndex++;
        }

        _globalGameState.Init(_bossWinCondution);

        _goToBossPastTime.Init(_bossSellectCondutions[currentBossIndex].BossEnemy);
    }

    private void OrderBosses()
    {
        _bossSellectCondutions = _bossSellectCondutions.OrderByDescending(boosSellectCondution => boosSellectCondution.ScoreToSellect).ToList();
    }

    [System.Serializable]
    private class BossSellectCondution
    {
        [SerializeField] private BossEnemy _bossEnemy;
        [SerializeField] private uint _scoreToSellect;

        public BossEnemy BossEnemy => _bossEnemy;
        public uint ScoreToSellect => _scoreToSellect;
    }
}
