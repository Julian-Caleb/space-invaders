using UnityEngine;

public class Invader : MonoBehaviour {
   
    public Sprite[] animationSprites; // Array of sprites
    public float animationTime = 0.5f; // Animation time
    private int _animationFrame;
    private SpriteRenderer _spriteRenderer;

    public System.Action killed;  

    private void Awake() {

        _spriteRenderer = GetComponent<SpriteRenderer>(); // take sprites

    }

    private void Start() {

        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime); // repeating invoke

    }

    private void AnimateSprite() {

        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length) {

            _animationFrame = 0;

        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];

    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) {

            this.killed.Invoke();
            this.gameObject.SetActive(false);

        }

    }

}
