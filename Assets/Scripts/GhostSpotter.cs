using System.Collections;
using UnityEngine;

public class GhostSpotter : MonoBehaviour
{
    [SerializeField] private GameObject GhostPingCollider;
    [SerializeField] private float pingDuration = 10f;

    private void OnEnable()
    {
        LanternLogic.GhostPing += GhostPing;
    }

    private void OnDisable()
    {
        LanternLogic.GhostPing -= GhostPing;
    }

    private void GhostPing()
    {
        StartCoroutine(PingRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spirit"))
        {
            GhostPingEffect effect = other.GetComponentInChildren<GhostPingEffect>();

            if (effect != null)
            {
                ParticleSystem GhostPingParticles = effect.GetComponent<ParticleSystem>();
                GhostPingParticles.Play();
            }
        }
    }

    private IEnumerator PingRoutine()
    {
       LanternLogic.IsGhostPingActive = true;
        GhostPingCollider.SetActive(true);

        yield return new WaitForSeconds(pingDuration);

        GhostPingCollider.SetActive(false);
        LanternLogic.IsGhostPingActive = (false);
    }
}
