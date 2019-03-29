using UnityEngine;

public class UISound : MonoBehaviour {

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
    }

    /// <summary>
    /// Plays the click sounds.
    /// </summary>
    /// <param name="soundClip">The click sound to play.</param>
    public void ClickSound(AudioClip soundClip)
    {
        // El código está hecho así ya que en un principio quise referenciar la variable static
        // del AudioManager directamente en el inspector de Unity en el botón pero no fue posible,
        // para llegar a esa variable hay que usar sí o sí script. En muchas escenas verás puesto
        // un objeto AudioManager pero al estar planteado este como static y siendo Singleton, no
        // podremos referirnos todo el tiempo al AM que está en la escena pq se rompería la referencia
        audioManager.PlaySpecialEffect(soundClip);
    }
}
