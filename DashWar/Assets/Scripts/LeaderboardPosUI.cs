using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPosUI : MonoBehaviour
{
    // Referencia a los elementos de cada posición en la tabla.  Es más conveniente un script que tenga todo bien
    // referenciado a tener que buscar desde afuera por tags o cosas que puedan cambiar
    public Text playerPosScore;
    public GameObject playerAnimation;
}
