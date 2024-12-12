using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;   // Assign in the Inspector

    private void Start()
    {
        // Set the initial volume based on AudioListener settings.
        volumeSlider.value = AudioListener.volume; // Initialize slider value

        // Add listener to update sound settings when slider value changes.
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Set volume based on the slider value
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // Mute sound (set volume to 0) when called
    public void Mute()
    {
        AudioListener.volume = 0f;
        volumeSlider.value = 0f; // Update slider to show muted state
    }

    // Unmute sound (restore slider value)
    public void Unmute()
    {
        AudioListener.volume = volumeSlider.value; // Restore volume
    }
}

