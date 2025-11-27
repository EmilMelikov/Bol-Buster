using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на компонент AudioSource
    public AudioClip[] musicTracks; // Массив аудиотреков

    void Start()
    {
        PlayNextTrack(); // Запускаем первый трек
    }

    void Update()
    {
        // Проверяем, закончился ли текущий трек
        if (!audioSource.isPlaying)
        {
            PlayNextTrack(); // Если трек закончился, воспроизводим следующий
        }
    }

    void PlayNextTrack()
    {
        // Генерируем случайный индекс трека
        int randomTrackIndex = Random.Range(0, musicTracks.Length);

        // Устанавливаем новый трек и воспроизводим его
        audioSource.clip = musicTracks[randomTrackIndex];
        audioSource.Play();
    }
}