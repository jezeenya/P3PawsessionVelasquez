using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetUIController : MonoBehaviour
{
    public Image feedImage, happinessImage, energyImage;

    public static PetUIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the Scene");
    }

    // Update is called once per frame
    public void UpdateImages(int food, int happiness, int energy, int foodTick = 0, int happinessTick = 0, int energyTick = 0)
    {
        feedImage.fillAmount = (float)food / 100;
        happinessImage.fillAmount = (float)happiness / 100;
        energyImage.fillAmount = (float)energy / 100;

        // Animate the bars moving up slightly
        if (foodTick != 0) StartCoroutine(PopUp(feedImage.rectTransform, foodTick));
        if (happinessTick != 0) StartCoroutine(PopUp(happinessImage.rectTransform, happinessTick));
        if (energyTick != 0) StartCoroutine(PopUp(energyImage.rectTransform, energyTick));
    }

    // Coroutine to make the UI element "jump" up then return
    private IEnumerator PopUp(RectTransform image, int tickValue)
    {
        Vector3 originalPos = image.anchoredPosition;
        float jumpAmount = tickValue * 2f; // Adjust multiplier for visual effect
        Vector3 targetPos = originalPos + new Vector3(0, jumpAmount, 0);

        float t = 0f;
        float duration = 0.2f; // Duration of the pop

        // Move up
        while (t < duration)
        {
            t += Time.deltaTime;
            image.anchoredPosition = Vector3.Lerp(originalPos, targetPos, t / duration);
            yield return null;
        }

        // Move back down
        t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            image.anchoredPosition = Vector3.Lerp(targetPos, originalPos, t / duration);
            yield return null;
        }

        image.anchoredPosition = originalPos; // Ensure exact reset
    }
}
