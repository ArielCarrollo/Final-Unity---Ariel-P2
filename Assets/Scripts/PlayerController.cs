using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SpeedX = 10;
    public float SpeedY = 7;
    public float Horizontal;
    public float Vertical;
    public Animator _compAnimator;
    public SpriteRenderer _compSpriteRenderer;
    public Rigidbody2D _compRigidbody2D;
    public AudioSource _compAudioSource;
    public AudioClip _daño;
    public AudioClip _muerte;
    public int Vidas = 3;
    void Awake()
    {
        _compAnimator = GetComponent<Animator>();
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            _compAudioSource.Play();
        }
        if (Vidas == 0)
        {
            _compAnimator.SetBool("Run?", true);
        }
        if (Horizontal == 1)
        {
            _compAnimator.SetBool("Run?", true);
        }
        else if (Horizontal < 1 )
        {
            _compAnimator.SetBool("Run?", false);
        }
        if (Vidas == 0)
        {
            _compAnimator.SetBool("muelte?", true);
        }
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(Horizontal * SpeedX, Vertical * SpeedY);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && 0 <= Vidas )
        {
            _compAnimator.SetBool("dañao?", true);
            _compAudioSource.clip = _daño;
            _compAudioSource.Play();
            QuitaVida();
        }
        if (collision.gameObject.tag == "EnemySpecial" && Horizontal == 0)
        {
            _compAnimator.SetBool("dañao?", true);
            _compAudioSource.clip = _daño;
            _compAudioSource.Play();
            QuitaVida();
        }
    }
    public void QuitaVida()
    {
        Vidas -= 1;
    }
    public void Muelte()
    {
        Destroy(this.gameObject);
    }
    public void QuitaDañao()
    {
        _compAnimator.SetBool("dañao?", false);
    }
    public void muelteaudio()
    {
        _compAudioSource.clip = _muerte;
        _compAudioSource.Play();
    }
}
