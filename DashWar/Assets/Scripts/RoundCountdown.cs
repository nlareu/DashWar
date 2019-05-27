using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCountdown : MonoBehaviour
{
    public float changeDelay = 0.5f;
    public float dashScreenTime = 0.5f;

    [Header("References")]
    [SerializeField] private Text countdownText;
    [SerializeField] private Text dashText;
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject initialUI;
    //[SerializeField] private float initialDelay = 0.25f;

	// Use this for initialization
	void Start ()
    {
        gm.FreezeAvatars();
        StartCoroutine(AnimateCountdown());
	}
	
    /// <summary>
    /// Makes the countdown before the round begins.
    /// </summary>
    /// <returns>Countdown time before round begins.</returns>
	IEnumerator AnimateCountdown()
    {
        countdownText.text = "3";
        int currentNumber = 3;

        yield return new WaitForSecondsRealtime(changeDelay);

        // The countdown itself
        while (currentNumber > 1)
        {
            currentNumber--;
            countdownText.text = currentNumber.ToString();

            yield return new WaitForSecondsRealtime(changeDelay);
        }
        
        countdownText.gameObject.SetActive(false);
        dashText.gameObject.SetActive(true);

        Invoke("RoundStart", 0.5f);
    }

    /// <summary>
    /// Clears the Screen
    /// </summary>
    private void RoundStart()
    {
        initialUI.SetActive(false);
        gm.AvatarsRoundStart();
    }
}
