using UnityEngine;

public class CatRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Material[] colorMaterials;
    public ParticleSystem particleSysteme;
    public AudioClip meowSound;

    private Renderer renderere;
    private AudioSource audioSource;

    private bool isTapped = false;

    private void Start()
    {
        renderere = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Зацикленное вращение объекта
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (!isTapped)
        {
            isTapped = true;

            // Выбор случайного цвета из массива цветов
            Material randomColorMaterial = colorMaterials[Random.Range(0, colorMaterials.Length)];

            // Изменение цвета объекта
            renderere.material = randomColorMaterial;

            // Воспроизведение партикл-системы
            particleSysteme.Play();

            // Воспроизведение звука мяуканья
            audioSource.PlayOneShot(meowSound);

            // Запуск корутины для сброса флага isTapped через 2 секунды
            StartCoroutine(ResetTappedFlag());
        }
    }

    private System.Collections.IEnumerator ResetTappedFlag()
    {
        // Задержка на 2 секунды
        yield return new WaitForSeconds(2f);
        isTapped = false;
    }
}
