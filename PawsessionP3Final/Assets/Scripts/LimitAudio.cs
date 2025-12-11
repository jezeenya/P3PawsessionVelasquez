using UnityEngine;

public class LimitAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    public void PlaySound1() => StartCoroutine(PlayAndStop(clip1));
    public void PlaySound2() => StartCoroutine(PlayAndStop(clip2));
    public void PlaySound3() => StartCoroutine(PlayAndStop(clip3));

    private System.Collections.IEnumerator PlayAndStop(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(1f);
        audioSource.Stop();
    }
}
