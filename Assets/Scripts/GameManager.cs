﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Power
{
    None = -1,
    Speed,
    Missile,
    Double,
    Laser,
    Option,
    Shield
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Power _currentPower = Power.None;
    public Image[] power;
    public Sprite[] powerImage;
    public Sprite[] selectImage;

    public Sound[] sound;
    private AudioSource _bgm;
    private AudioSource _sfx;

    private Player _player;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        CreateAudioSource();
    }

    private void Start()
    {
        if (power.Length == 0 || powerImage.Length == 0 || selectImage.Length == 0)
        {
            throw new System.NullReferenceException("List not found.");
        }

        if (!(power.Length == powerImage.Length && powerImage.Length == selectImage.Length))
        {
            throw new System.NullReferenceException("Each lists length are not equal.");
        }

        _player = FindObjectOfType<Player>();
    }

    private void CreateAudioSource()
    {
        for (int i = 0; i < 2; i++)
        {
            var temp = new GameObject
            {
                transform =
                {
                    name = i == 0 ? "BGM" : "SFX",
                    parent = transform
                }
            };
            if (i == 0)
            {
                _bgm = temp.AddComponent<AudioSource>();
                _bgm.loop = true;
                _bgm.playOnAwake = true;
            }
            else
            {
                _sfx = temp.AddComponent<AudioSource>();
                _sfx.loop = false;
                _sfx.playOnAwake = false;
            }
        }
    }

    private static int PowerCount()
    {
        return System.Enum.GetValues(typeof(Power)).Length;
    }

    public void AddPower()
    {
        PlaySFX("Item");
        if ((int)_currentPower < PowerCount() - 1)
        {
            _currentPower++;
        }

        SetPowerUI();
    }

    private void SetPowerUI()
    {
        for (int i = 0; i < PowerCount() - 1; i++)
        {
            power[i].sprite = i == (int)_currentPower ? selectImage[i] : powerImage[i];
        }
    }

    public void SetPower()
    {
        if (_currentPower != Power.None)
        {
            PlaySFX("Use");
        }
        _player.PowerUp(_currentPower);
        _currentPower = Power.None;
        SetPowerUI();
    }

    public int WherePlayerVertical(Vector2 position)
    {
        const float y = 0.1f;

        if (position.y + y < _player.transform.position.y)
        {
            return 1;
        }

        if (position.y - y > _player.transform.position.y)
        {
            return -1;
        }

        return 0;
    }

    public Vector2 AimPlayer(Vector2 position)
    {
        return new Vector2(_player.transform.position.x - position.x, _player.transform.position.y - position.y).normalized;
    }

    public void PlaySFX(string name)
    {
        var newClip = (from i in sound where i.name == name select i.clip).FirstOrDefault();

        if (newClip == null)
        {
            throw new System.NullReferenceException("Audio clip not found");
        }
        
        _sfx.PlayOneShot(newClip);
    }
    
    public void PlayBGM(string name)
    {
        var newClip = (from i in sound where i.name == name select i.clip).FirstOrDefault();

        if (newClip == null)
        {
            throw new System.NullReferenceException("Audio clip not found");
        }

        _bgm.clip = newClip;
        _bgm.Play();
    }
}