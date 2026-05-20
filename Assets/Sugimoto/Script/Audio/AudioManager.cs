using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] bgmClips;
    [SerializeField] private AudioClip[] seClips;

    private Dictionary<string, AudioClip> _bgmDict = new();
    private Dictionary<string, AudioClip> _seDict = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Init();
    }

    public void Start()
    {
        //Žn‚ß‚É—¬‚·‰¹‚ð“ü‚ê‚é
        PlayBGM("", 0.3f);
    }

    private void Init()
    {
        foreach (var clip in bgmClips)
        {
            if (!_bgmDict.ContainsKey(clip.name))
                _bgmDict.Add(clip.name, clip);
        }

        foreach (var clip in seClips)
        {
            if (!_seDict.ContainsKey(clip.name))
                _seDict.Add(clip.name, clip);
        }
    }

    // =============================
    // BGM
    // =============================

    public void PlayBGM(string name, float volume = 1f)
    {
        if (!_bgmDict.TryGetValue(name, out var clip))
        {
            Debug.LogWarning($"BGM not found: {name}");
            return;
        }

        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void FadeOutBGM(float duration)
    {
        StartCoroutine(FadeOutCoroutine(duration));
    }

    private System.Collections.IEnumerator FadeOutCoroutine(float duration)
    {
        float startVolume = bgmSource.volume;

        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(startVolume, 0f, time / duration);
            yield return null;
        }

        bgmSource.Stop();
        bgmSource.volume = startVolume;
    }

    // =============================
    // SE
    // =============================

    public void PlaySE(string name, float volume = 1f)
    {
        if (!_seDict.TryGetValue(name, out var clip))
        {
            Debug.LogWarning($"SE not found: {name}");
            return;
        }

        seSource.PlayOneShot(clip, volume);
    }

    // =============================
    // Utility
    // =============================

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSEVolume(float volume)
    {
        seSource.volume = volume;
    }
}
