using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Fields

    public static AudioManager instance;
    private AudioSource mainSource;

    #endregion

    #region Properties

    /// <summary>
    /// Gets and sets the current audioclip to play.
    /// </summary>
    public AudioClip CurrentClip
    {
        get
        {
            return mainSource.clip;
        }
        set
        {
            mainSource.Stop();
            mainSource.clip = value;
            mainSource.Play();
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    void Awake ()
    {
        // Singleton
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        mainSource = GetComponent<AudioSource>();
	}

    #endregion
}
