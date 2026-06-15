using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] private GameObject UiObject;
    [SerializeField]private Image staminaFill;

    public void SetVisible(bool value)
    {
        UiObject?.SetActive(value);
    }
    public void SetStaminaFill(float value, float maxValue)
    {
        if (staminaFill != null)
        {
            staminaFill.fillAmount = value/maxValue;
        }
    }
}
