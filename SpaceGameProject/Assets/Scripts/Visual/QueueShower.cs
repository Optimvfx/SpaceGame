using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueShower : MonoBehaviour
{
    [SerializeField] private List<Graphic> _toShow;
    [SerializeField] private UFloat _showSpeed;

    [SerializeField] private UFloat _showDellayInSeconds;

    private void Awake()
    {
        if (_toShow.Count <= 1)
            return;

        foreach (var showing in _toShow)
            showing.color += new Color(0,0,0,-1);

        _toShow[0].color = new Color(_toShow[0].color.r, _toShow[0].color.g, _toShow[0].color.b, 1);

        StartCoroutine(ShowNext(0));
    }

    private System.Collections.IEnumerator ShowNext(int currentIndex)
    {
        const int maximalProgres = 1;
        const int nextIndexOffset = 1;
        const int collectionMinValue = 0;

        if (currentIndex < collectionMinValue || currentIndex >= _toShow.Count)
            throw new System.ArgumentException();

        var current = _toShow[currentIndex];

        var nextToShowIndex = (currentIndex + nextIndexOffset) % (_toShow.Count);
        var next = _toShow[nextToShowIndex];

        var progres = 0f;

        while(progres < maximalProgres)
        {
            progres += _showSpeed * Time.deltaTime;

            current.color = new Color(current.color.r, current.color.g, current.color.b, maximalProgres - progres);
            next.color = new Color(next.color.r, next.color.g, next.color.b, progres);

            yield return null;
        }

        yield return new WaitForSeconds(_showDellayInSeconds);

        StartCoroutine(ShowNext(nextToShowIndex));
    }
}
