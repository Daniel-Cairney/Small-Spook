using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpiritCollect : MonoBehaviour
{
    [SerializeField] private GameObject spiritBody;
    [SerializeField] private ParticleSystem spiritFlames;
    [SerializeField] private AudioSource spiritAudio;
    [SerializeField] private AudioClip spiritClip;

    [SerializeField] private GameObject spiritOrb;

    [Header("Movement")]
    [SerializeField] private float spiritOrbSpeed = 2f;
    [SerializeField] private float acceleration = 3f;
    [SerializeField] private float maxSpeed = 10f;

    [SerializeField] private Transform playerTransform;
    private bool moveToPlayer = false;
    [SerializeField] private float currentSpeed;

    private void Update()
    {
        if (moveToPlayer && playerTransform != null)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            spiritOrb.transform.position = Vector3.MoveTowards(
            spiritOrb.transform.position,
            playerTransform.position,
            spiritOrbSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

       if (other.CompareTag("Player"))
       {
            spiritJuice();
            SpiritMove(other.transform);
            Debug.Log("IK ZIE JE MOGOOL");
       }
      
    }

    private void SpiritMove(Transform player)
    {
        playerTransform = player;
        currentSpeed = spiritOrbSpeed;      
        spiritOrb.SetActive(true);
        moveToPlayer = true;
    }

    private void spiritJuice()
    {
        spiritBody.SetActive(false);
        spiritAudio.PlayOneShot(spiritClip);
        GetComponent<Collider>().enabled = false;
        spiritOrb.SetActive(true);
        spiritFlames.Play();
    }
}
