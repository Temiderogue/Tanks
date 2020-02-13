using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioClip _shootSound, _monsterHit, _healSound, _playerDeath, _tankHit;
    private static AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _shootSound = Resources.Load<AudioClip>("Shoot");
        _monsterHit = Resources.Load<AudioClip>("MonsterHit");
        _healSound = Resources.Load<AudioClip>("Heal");
        _playerDeath = Resources.Load<AudioClip>("PlayerDeath");
        _tankHit = Resources.Load<AudioClip>("TankHit");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Shoot":
                _audioSource.PlayOneShot(_shootSound);
                break;
            case "MonsterHit":
                _audioSource.PlayOneShot(_monsterHit);
                break;
            case "Heal":
                _audioSource.PlayOneShot(_healSound);
                break;
            case "PlayerDeath":
                _audioSource.PlayOneShot(_playerDeath);
                break;
            case "TankHit":
                _audioSource.PlayOneShot(_tankHit);
                break;
        }
    }
}
