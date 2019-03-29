using UnityEngine;

public class AudioManager : MonoBehaviour {

    #region Fields

    public static AudioManager instance;
    [SerializeField]
    private AudioSource mainSource;
    [SerializeField]
    private AudioSource specialEffectsSource;

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
            // Only start playing again if it's a different track
            if (value == mainSource.clip)
            {
                //Debug.Log("La música es la misma, continuará reproduciéndose la misma pista");
                return;
            }

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

        //mainSource = GetComponent<AudioSource>();
	}

    /// <summary>
    /// Plays the given audio clip.
    /// </summary>
    /// <param name="sfxClip">The special effects audio clip to play.</param>
    public void PlaySpecialEffect(AudioClip sfxClip)
    {
        specialEffectsSource.clip = sfxClip;
        specialEffectsSource.Play();
    }

    #endregion
}
