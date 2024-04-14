using UnityEngine;

public class BGMTrigger : MonoBehaviour
{
    public string BGMName = "BGM02";
    private void OnBecameVisible()
    {
        GameManager.Instance.PlayBGM(BGMName);
    }
}