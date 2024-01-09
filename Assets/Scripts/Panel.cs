using UnityEngine;

public class Panel : MonoBehaviour
{
    public void retry()
    {
        GameManager.Instance.Retry();
    }
}
