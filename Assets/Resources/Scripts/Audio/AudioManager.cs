using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source), "Provided AudioSource is null");
        }

        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BurgerDamage,
            Resources.Load<AudioClip>("BurgerDamage"));
        audioClips.Add(AudioClipName.BurgerDeath,
            Resources.Load<AudioClip>("BurgerDeath"));
        audioClips.Add(AudioClipName.BurgerShot,
            Resources.Load<AudioClip>("BurgerShot"));
        audioClips.Add(AudioClipName.Explosion,
             Resources.Load<AudioClip>("Explosion"));
        audioClips.Add(AudioClipName.MenuButtonClick,
             Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.PauseGame,
              Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.TeddyShot,
            Resources.Load<AudioClip>("TeddyShot"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        if (!initialized)
        {
            Debug.LogError("AudioManager not initialized.");
            return;
        }

        if (!audioClips.TryGetValue(name, out AudioClip clip))
        {
            Debug.LogError($"AudioClip with name '{name}' not found.");
            return;
        }

        if (clip == null)
        {
            Debug.LogError($"AudioClip '{name}' is null.");
            return;
        }

        audioSource.PlayOneShot(audioClips[name]);
    }
}
