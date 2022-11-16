using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public Projectile laserPrefab;

    public float speed = 15.0f;

    private bool _laserActive;

    public Sprite[] animationSprites; // Array of sprites
    public float animationTime = 1.0f; // Animation time
    private int _animationFrame;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {

        _spriteRenderer = GetComponent<SpriteRenderer>(); // take sprites

    }

    private void Start() {

        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime); // repeating invoke

    }

    private void Update() {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }

    }    

    private void Shoot() {

        if (!_laserActive) {
            _laserActive = true;
            Projectile laser = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            laser.destroyed += LaserDestroyed;
        }
    }

    private void LaserDestroyed() {

        _laserActive = false;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader") || other.gameObject.layer == LayerMask.NameToLayer("Missile") )
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void AnimateSprite() {

        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length) {

            _animationFrame = 0;

        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];

    }

}
