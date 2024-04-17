using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Необходимо для работы со слайдером

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float sensitivity;
    public float gravity;
    private float mouseX;
    private float mouseY;
    private float vertical;
    private float horizontal;

    public Vector2 clampangle;
    private Vector3 Velocity;
    private Vector2 angle;
    public Transform cameraTransform;

    private CharacterController charactercontroller;
    private Animator animator;

    public Slider staminaSlider; // Слайдер для отображения стамины
    public float maxStamina = 100;
    private float currentStamina;

    private void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        if (animator == null)
        {
            Debug.LogWarning("Animator component is not found on " + gameObject.name);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (animator == null) return;

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        Vector3 playerMovementInput = new Vector3(horizontal, 0.0f, vertical);
        Vector3 moveVector = transform.TransformDirection(playerMovementInput);

        bool isMoving = vertical != 0 || horizontal != 0;
        bool isRunning = isMoving && Input.GetKey(KeyCode.LeftShift) && currentStamina > 0;

        if (isRunning)
        {
            movespeed = 6;
            animator.SetInteger("popka", 2);
            currentStamina -= 30 * Time.deltaTime; // Израсходовать стамину при беге
        }
        else
        {
            movespeed = isMoving ? 2f : 0f;
            animator.SetInteger("popka", isMoving ? 1 : 0);
            currentStamina += 15 * Time.deltaTime; // Восстановление стамины
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaSlider.value = currentStamina; // Обновление слайдера стамины

        // Проверка, заземлен ли игрок
        if (charactercontroller.isGrounded)
        {
            Velocity.y = -1f;
        }
        else
        {
            Velocity.y -= gravity * Time.deltaTime;
        }

        charactercontroller.Move(moveVector * (isRunning && currentStamina > 0 ? movespeed : 2f) * Time.deltaTime);
        charactercontroller.Move(Velocity * Time.deltaTime);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        angle.x -= mouseY * sensitivity;
        angle.y -= mouseX * -sensitivity;

        angle.x = Mathf.Clamp(angle.x, -clampangle.x, clampangle.y);

        Quaternion rotation = Quaternion.Euler(angle.x, angle.y, 0.0f);
        Quaternion rotationTwo = Quaternion.Euler(0.0f, angle.y, 0.0f);
        transform.rotation = rotationTwo;
        cameraTransform.rotation = rotation;
    }
}
