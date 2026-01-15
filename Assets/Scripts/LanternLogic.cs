using UnityEngine;
using UnityEngine.Events;

public class LanternLogic : MonoBehaviour
{
    [SerializeField] private Light lanternLight;
    [SerializeField] private float intensityPerSpirit = 0.5f;
    [SerializeField] private float maxIntensity = 20f;
    [SerializeField] private float drainDuration = 30f;
    private float currentIntensity;
    private bool isOn = true;

    private float targetIntensity;


    private void Start()
    {
        currentIntensity = maxIntensity;
        targetIntensity = maxIntensity;
        lanternLight.intensity = currentIntensity;

    }

    private void Update()
    {
        if (!isOn)
            return;

        // 1. Drain the TARGET over time
        float drainPerSecond = maxIntensity / drainDuration;

        targetIntensity -= drainPerSecond * Time.deltaTime;
        targetIntensity = Mathf.Max(targetIntensity, 0f);

        // 2. Smoothly move current toward target (fade up or down)
        currentIntensity = Mathf.MoveTowards(
            currentIntensity,
            targetIntensity,
            drainPerSecond * Time.deltaTime
        );

        lanternLight.intensity = currentIntensity;

        // 3. Turn off when empty
        if (currentIntensity <= 0f)
        {
            isOn = false;
            lanternLight.enabled = false;
        }


    }
    private void OnEnable()
    {
        SpiritDelete.SpiritCollected += LanternFuelUp;
    }

    private void OnDisable()
    {
        SpiritDelete.SpiritCollected -= LanternFuelUp;
    }

    private void LanternFuelUp()
    {
        targetIntensity = Mathf.Min(
            targetIntensity + intensityPerSpirit,
            maxIntensity
        );


        isOn = true;
        lanternLight.enabled = true;
    }

}

