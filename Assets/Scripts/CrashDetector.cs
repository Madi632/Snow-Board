using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem painEffect;
    [SerializeField] float feelingTheBump = 0.5f;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed) 
        {
            hasCrashed = true;
            FindAnyObjectByType<PlayerController>().DisableControls();
            painEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", feelingTheBump);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
