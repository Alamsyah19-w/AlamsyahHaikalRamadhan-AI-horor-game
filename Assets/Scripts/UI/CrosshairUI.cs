using UnityEngine;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{
    [SerializeField] private Image crosshairImage;
    [SerializeField] private Color normalColor= Color.white;
    [SerializeField] private Color highlightColor = Color.white;
    private void Awake()
    {
        SetHighlight(false);
    }
    public void SetHighlight(bool value)
    {
        if (value)
        {
            crosshairImage.color=highlightColor;
        }
        else
        {
            crosshairImage.color=normalColor;
        }
    }

}
