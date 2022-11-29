using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoVisualization : MonoBehaviour
{
    [SerializeField] private TMP_Text _topIndex;
    [SerializeField] private TMP_Text _lable;

    [SerializeField] private TMP_Text _moneyText;

    public void Visualize(TopMenu.PlayerInfo playerInfo, uint topIndex)
    {
        _topIndex.text = topIndex.ToString();

        _lable.text = playerInfo.Username;

        _moneyText.text = playerInfo.Money.ToString();
    }
}
