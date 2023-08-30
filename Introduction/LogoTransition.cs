using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Transição de Cenas;

public class LogoTransition : MonoBehaviour
{   
    private CanvasGroup canvasGroup; //instância o CanvasGroup, que realiza o fade da imagem;
   
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>(); //Pega o atual CanvasGroup atrelado ao objeto atual;
        StartCoroutine(FadeOut(4.0f)); // Cria uma Coroutine chamando o Enumerator "FadeOut";
    }
    private IEnumerator FadeOut(float duration)//Enumerator é utilizado muito para privates, conversões e chamadas de outros scripts, animações e transições
    {
        float startAlpha = canvasGroup.alpha; //Atribui a variável Alpha (que realiza o fade: 1 = sem fade, 0 = com fade)
        float time = 0;
        while(time < duration)
        {
            time += Time.deltaTime; //conforme o tempo passa, adicionar mais um no float time;
            canvasGroup.alpha = Mathf.Lerp(startAlpha,0,time/duration); // Altera o Alpha do CanvasGroup com o Mathf.Lerp, que degradativamente realiza a transição indo de 1 até 0;
            yield return null; //sem contagem de tempo para retorno para outra função;
        }
        canvasGroup.alpha = 0;// seta o alpha para zero após terminar, para não voltar ativo sem fade;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Chama a próxima cena do jogo;
    }
}
