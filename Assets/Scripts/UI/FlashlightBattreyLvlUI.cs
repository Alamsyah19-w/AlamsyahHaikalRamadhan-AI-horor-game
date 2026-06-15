using UnityEngine;
using UnityEngine.UI;

public class FlashlightBattreyLvlUI : MonoBehaviour
{
    [SerializeField] private GameObject uiObject;
    [SerializeField] private Image battreyFill;
    [SerializeField] private Color highColor= Color.white;
    [SerializeField] private Color mediumColor= Color.white;
    [SerializeField] private Color lowColor= Color.white;

    public void SetVisibility(bool value)
    {
        uiObject?.SetActive(value);
    }
    public void UpdateBattreyUI(float value,float maxValue)
    {
        float fillAmount = value/maxValue;
        battreyFill.fillAmount=fillAmount;

        Color color =highColor;
        if (fillAmount <0.25f)
        {
            color=lowColor;
        }
        else if (fillAmount >0.25f && fillAmount <0.5f)
        {
            color=mediumColor;
        }
        battreyFill.color=color;
    }
}
