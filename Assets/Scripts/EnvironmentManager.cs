using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private static int season = 0;
    private static EnvironmentManager instance;
    private static float colorChangeTime = 5f;

    public GameObject rainParticle;
    public GameObject snowParticle;
    public GameObject leafParticle;

    private static Color blueSummer = new Color(0.2980392f, 0.7607843f, 1);
    private static Color darkRainfall = new Color(0.141f, 0.264857f, 0.3396226f);
    private static Color whiteWinter = new Color(0.747953f, 0.8005838f, 0.8301887f);
    private static Color brownAutumn = new Color(0.7735849f, 0.6157378f, 0.3612495f);

    private void Awake()
    {
        instance = this;
        rainParticle.SetActive(false);
        snowParticle.SetActive(false);
        leafParticle.SetActive(false);
        StartCoroutine(ColorLerp(blueSummer));
    }
    public static void ChangeSeason()
    {
        season = (season + 1) % 4;
        switch (season)
        {
            case 0:
                instance.rainParticle.SetActive(false);
                instance.snowParticle.SetActive(false);
                instance.leafParticle.SetActive(false);
                instance.StartCoroutine(instance.ColorLerp(blueSummer));
                break;
            case 1:
                instance.rainParticle.SetActive(true);
                instance.snowParticle.SetActive(false);
                instance.leafParticle.SetActive(false);
                instance.StartCoroutine(instance.ColorLerp(darkRainfall));
                break;
            case 2:
                instance.rainParticle.SetActive(false);
                instance.snowParticle.SetActive(true);
                instance.leafParticle.SetActive(false);
                instance.StartCoroutine(instance.ColorLerp(whiteWinter));
                break;
            case 3:
                instance.rainParticle.SetActive(false);
                instance.snowParticle.SetActive(false);
                instance.leafParticle.SetActive(true);
                instance.StartCoroutine(instance.ColorLerp(brownAutumn));
                break;
        }
    }

    IEnumerator ColorLerp(Color endColor)
    {
        for (float t = 0; t < colorChangeTime; t+=0.1f)
        {
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, endColor, t / colorChangeTime);
            yield return null;
        }
    }
}
