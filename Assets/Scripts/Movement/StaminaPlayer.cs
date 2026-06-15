using System.Collections;
using Unity.AppUI.UI;
using UnityEngine;

public class StaminaPlayer : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float sprintStaminaCost = 20f;
    [SerializeField] private float staminaRecoveryRate = 20f;
    [SerializeField] private MovementPlayer movementPlayer;
    [SerializeField] private float currentStamina;
    private Coroutine stopRegenStaminaCorotine;
    private bool isWaitingRegenStamina;
    private void Awake()
    {
        currentStamina = maxStamina;
        HUDManager.Instance.StaminaUI.SetStaminaFill(currentStamina,maxStamina);
    }
    private void Update()
    {
        CalculateStamina();
    }
    private void CalculateStamina()
    {
        if (movementPlayer.Sprint)
        {
            if (stopRegenStaminaCorotine != null)
            {
                StopCoroutine(stopRegenStaminaCorotine);
                stopRegenStaminaCorotine = null;
            }

            isWaitingRegenStamina=false;

            if (currentStamina > 0f)
            {
                currentStamina -= sprintStaminaCost * Time.deltaTime;
            }
            else
            {
                Invoke("SprintStop", 1f);
            }
            
        }
        else
        {
            if (currentStamina< maxStamina)
            {
                currentStamina += staminaRecoveryRate * Time.deltaTime;
            }
            else if (isWaitingRegenStamina == false)
            {
                stopRegenStaminaCorotine =StartCoroutine(StopRegenStaminaWait());
                isWaitingRegenStamina= true;
            }
           
        }
        
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        HUDManager.Instance.StaminaUI.SetStaminaFill(currentStamina,maxStamina);
    }
    private void SprintStop()
    {
        movementPlayer.SetSprint(false);
    }

    private IEnumerator StopRegenStaminaWait()
    {
        yield return new WaitForSeconds(1);
        HUDManager.Instance.StaminaUI.SetVisible(false);
    }
}
