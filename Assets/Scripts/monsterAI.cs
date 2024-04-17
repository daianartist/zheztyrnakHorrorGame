using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Animator anim;
    public Transform player;
    private RaySystem raySystem;
    public float catchDistance = 2.0f;// Ссылка на компонент RaySystem
    Vector3 dest;

    void Start()
    {
        // Находим компонент RaySystem, предполагая, что он находится на игроке
        raySystem = player.GetComponent<RaySystem>();

        // Проверка на null, чтобы избежать ошибок
        if (raySystem == null)
        {
            Debug.LogError("RaySystem component not found on player object!");
            enabled = false; // Отключаем скрипт, если компонент не найден
        }
    }

    void Update()
    {
        dest = player.position;
        ai.destination = dest;

        // Используем значение rune из RaySystem для определения скорости и анимации
        switch (raySystem.rune)
        {
            case 1:
                ai.speed = 1.5f;
                anim.speed = 0.2f;
                break;
            case 2:
                ai.speed = 1.7f;
                anim.speed = 0.4f;
                break;
            case 3:
                ai.speed = 1.9f;
                anim.speed = 0.6f;
                break;
            case 4:
                ai.speed = 2.5f;
                anim.speed = 0.8f;
                break;
            case 5:
                ai.speed = 3f;
                anim.speed = 1f;
                break;
            default:
                ai.speed = 1f;  // Базовая скорость, если рун меньше 1
                anim.speed = 0.1f;
                break;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < catchDistance)
        {
            player.GetComponent<JumpscareTrig>().TriggerJumpscare(); // Активируем jumpscare
        }
    }
}
