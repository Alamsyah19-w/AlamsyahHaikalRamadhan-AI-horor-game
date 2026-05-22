using UnityEngine;

public class StaminaPlayer : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float sprintStaminaCost = 20f;
    [SerializeField] private float staminaRecoveryRate = 20f;
    [SerializeField] private MovementPlayer movementPlayer;
    [SerializeField] private float currentStamina;
    private void Awake()
    {
        currentStamina = maxStamina;
    }
    private void Update()
    {
        CalculateStamina();
    }
    private void CalculateStamina()
    {
        if (movementPlayer.Sprint)
        {
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
            currentStamina += staminaRecoveryRate * Time.deltaTime;
        }
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }
    private void SprintStop()
    {
        movementPlayer.SetSprint(false);
    }
}
