using System.Collections;
using UnityEngine;

public class WinEffect : MonoBehaviour
{
    /*
     Este script es un intento de hacer una especie de efecto de slowdonw mientras subes y al final poner pantalla de win,
    pero como veras, es un intento, y ni con el chat gpt lo logre consegir :'c (la semana que viene miro como hacerlo)
     */

    public float slowdownDuration = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.StartCoroutine(SlowdownAndDie(player));
        }
    }

    private IEnumerator SlowdownAndDie(Player player)
    {
        player.DisableInputs();

        MoveBehaviour mb = player.GetComponent<MoveBehaviour>();
        float originalSpeed = mb.speed;
        float t = 0;

        while (t < slowdownDuration)
        {
            mb.speed = Mathf.Lerp(originalSpeed, 0, t / slowdownDuration);
            t += Time.deltaTime;
            yield return null;
        }

        mb.speed = 0;
        player.Win(); // llamas a tu animación + UI
    }
}