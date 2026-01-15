
using UnityEngine;

public class SugmaPop : MonoBehaviour
{
    public GameObject shitPost;
    public AudioSource fuh;
    public AudioClip fuhClip;
    public Animator fuhFade;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            shitPost.SetActive(true);
            fuh.PlayOneShot(fuhClip);
            fuhFade.Play("fuhFade");
            
        }

        
        
    }
}
