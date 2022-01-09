using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameModeSwitcher), typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [Header("Звуковые эффекты игрока")]
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private AudioClip _blobDownSound;
    [SerializeField] private AudioClip _blobUPSound;
    [Space(15), Header("Звуковые эффекты игры")]
    [SerializeField] private AudioClip _runMusic;
    [SerializeField] private AudioClip _idleMusic;

    private GameModeSwitcher _gameModeSwitcher;
    private AudioSource _gameAudioSource;

    private void Awake()
    {
        _gameModeSwitcher = GetComponent<GameModeSwitcher>();
        _gameAudioSource = GetComponent<AudioSource>();

        PlaySound(_gameAudioSource, _idleMusic);
    }

    private void OnEnable()
    {
        _player.LostBodyPart += OnLostBodyPart;
        _player.RepaireBodyPart += OnRepaireBodyPart;
        _gameModeSwitcher.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _player.LostBodyPart -= OnLostBodyPart;
        _gameModeSwitcher.GameStarted -= OnGameStarted;
    }

    private void OnLostBodyPart()
    {
        PlaySound(_playerAudioSource, _blobDownSound);
    }

    private void OnRepaireBodyPart()
    {
        PlaySound(_playerAudioSource, _blobUPSound);
    }

    private void OnGameStarted()
    {
        PlaySound(_gameAudioSource, _runMusic);
    }

    private void PlaySound(AudioSource musicPlayer, AudioClip sound)
    {
        musicPlayer.clip = sound;
        musicPlayer.Play();
    }
}
