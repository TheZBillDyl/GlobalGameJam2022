using UnityEngine;
public class BlockSoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    AudioSource src;
    Rigidbody rb;
    [SerializeField] float soundThreshold;
    bool canPlaySound;
    float coolDown = 2, timer = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (!src.isPlaying && canPlaySound)
        {
            int rand = Random.Range(0, sounds.Length);
            src.clip = sounds[rand];
            src.pitch = Random.Range(0.5f, 1.4f);
            src.Play();
        }

    }

    private void OnDestroy()
    {
        src.Stop();
    }

    private void Update()
    {
        if (timer < coolDown)
        {
            timer += Time.deltaTime;
        } 
        else
        {
            if(rb.velocity.magnitude > soundThreshold && !canPlaySound)
            {
                canPlaySound = true;
            }
        }
    }
}
