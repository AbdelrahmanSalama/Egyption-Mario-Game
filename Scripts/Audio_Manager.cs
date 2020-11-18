using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]                                         // Setting a range for volume
     public float volume =0.7f;
    [Range(0.5f, 1.5f)]                                     // Setting a range for pitch
    public float pitch = 1f;
    [Range(0.5f, 1f)]
    public float randomVolume = 0.1f;
    [Range(0.5f, 1f)]
    public float randomPitch = 0.1f;
    private AudioSource source;
    public void SetSource (AudioSource _source)
    {

            source = _source;
            source.clip = clip;
    }


    public void Play()
    {

        source.volume = 0.193f;//volume * (1 + Random.Range(-randomVolume / 2f, randomVolume / 2f));
        source.pitch = 1.046448f;//pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));;
        source.Play();

    }
} 
public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    [SerializeField]
    Sound[] sounds;


    private void Awake()                                                                 //Runs before Start() method.
    {
        if(instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene!");
        }else
        {
            instance = this; 
        }
    }
    private void Start() 
    {
        
        for(int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource (_go.AddComponent<AudioSource>());
            if(sounds[i].name == "Background Music")
            {
                _go.GetComponent<AudioSource>().loop = true;
            }else
            {
                return;
            }
            

           /* if(sounds[i].name == "Background Music")
            {
                 GetComponent<AudioSource>().loop = true;
            }*/
        }

        PlaySound("Background Music");
        
        
        
    }


    private void Update() {
        
       
    }


    public void PlaySound(string _name)
    {

        for(int i = 0; i < sounds.Length; i++)
        {

            if(sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
}
