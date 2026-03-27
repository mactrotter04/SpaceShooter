using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    [Header("Shoot SFX")]
    [SerializeField] AudioClip shootSFX;
    [SerializeField][Range(0f, 1f)] float shootSFXVolume = 1f;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageSFX;
    [SerializeField][Range(0f, 1f)] float damageSFXVolume = 1f;

    static Audiomanager instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootSFX()
    {
        PlayClip(shootSFX, shootSFXVolume);
    }

    public void PlayDamageSFX()
    {
        PlayClip(damageSFX, damageSFXVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
}
