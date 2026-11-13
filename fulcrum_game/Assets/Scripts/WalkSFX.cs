using System.Collections.Generic;
using UnityEngine;

public class WalkSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> sounds;

    [SerializeField] private float stepInterval;
    private float stepTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 

        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            // Add to step timer if moving
            stepTimer += Time.deltaTime;

            // Play random footstep sound
            if (stepTimer > stepInterval)
            {

                int randomIndex = Random.Range(0, sounds.Count);
                audioSource.PlayOneShot(sounds[randomIndex]);
                stepTimer = 0;
                
            }
        }
    }
}
