using UnityEngine;

public class DestroyOnTimeStoped : MonoBehaviour
{
    private void Update()
    {
        if(TimeExtenstions.IsTimeStoped())
            Destroy(gameObject);
    }
}
