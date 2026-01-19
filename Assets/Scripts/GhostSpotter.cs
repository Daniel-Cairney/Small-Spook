using UnityEngine;

public class GhostSpotter : MonoBehaviour
{
    [SerializeField] private GameObject GhostPingCollider;

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
        GhostPingCollider.SetActive(true);
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
}
