using System.Collections;
using UnityEngine;

public class InfoLockedDoorUI : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    [SerializeField] private TMPro.TextMeshProUGUI infoText;
    [SerializeField] private float duration = 1f;

    private Coroutine hideCoroutine;

    public void ShowInfo(string text)
    {
        ShowInfo(text, duration);
    }

    public void ShowInfo(string text, float customDuration)
    {
        SetInfoText(text);
        SetVisible(true);

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(HideAfterDelay(customDuration));
    }

    public void SetVisible(bool value)
    {
        uiObject?.SetActive(value);
    }

    public void SetInfoText(string text)
    {
        infoText?.SetText(text);
    }

    public void SetDuration(float value)
    {
        duration = value;
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetVisible(false);
        hideCoroutine = null;
    }
}
