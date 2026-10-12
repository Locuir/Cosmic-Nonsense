
using TMPro;
using UnityEngine;
using System.Collections;
using Unity.Mathematics;
using UnityEngine.UI;
public class StartTextEffect : MonoBehaviour
{
    [SerializeField]  private TMP_Text StartText;
    [SerializeField]  private float FadeDuration;
    [SerializeField]  private float VisableDuration;
    [SerializeField]  private float HiddenDuration;


    private Color OrignalColor;
    private Coroutine FadeCorutine;
    private void Awake()
    {
        if (StartText == null)
        {
            StartText = GetComponent<TMP_Text>();

        }
        OrignalColor = StartText.color;
    }

    private void OnEnable()
    {
        StartCoroutine(fadeloop());
    }

    private IEnumerator fadeloop()
    {
        while (true)
        {
            yield return Fade(0f,1f);

            yield return new WaitForSeconds(VisableDuration);

            yield return Fade(1f, 0f);

            yield return new WaitForSeconds(HiddenDuration);



        }

    }


    private IEnumerator Fade(float StartAlpha, float EndAlpha)
    {
        float elapsed = 0f;

        while (elapsed < FadeDuration)
        {

            elapsed += Time.deltaTime;

            float alpha = Mathf.Lerp(
                StartAlpha,
                EndAlpha,
                Mathf.Clamp01(elapsed / FadeDuration)
                );



            StartText.color = new Color(

                OrignalColor.r,
                OrignalColor.g,
                OrignalColor.b,
                alpha


                );



            yield return null;

        }
        StartText.color = new Color(
             OrignalColor.r,
                OrignalColor.g,
                OrignalColor.b,
                EndAlpha

                );


        }



}
