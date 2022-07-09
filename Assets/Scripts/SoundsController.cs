using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundsController : MonoBehaviour
{
    public static SoundsController Instance;
    private AudioSource audioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else if (Instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        
    }
}
