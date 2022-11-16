using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {
   
    public Sprite[] animationSprites; // Array of sprites

    public float animationTime = 0.3f; // Animation time

    public System.Action killed;

    private SpriteRenderer _spriteRenderer; 

    private int _animationFrame; 

    private int hp = 1000;
    private int score;

    public Text MyscoreText;

    private void Awake() {

        _spriteRenderer = GetComponent<SpriteRenderer>(); // take sprites

    }

    private void Start() {

        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime); // repeating invoke
        PlayerPrefs.SetInt("hp", hp);
        score = PlayerPrefs.GetInt("currentscore");

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

            hp = hp - 20;
            score = score + 100;
            PlayerPrefs.SetInt("hp", hp);
            PlayerPrefs.SetInt("currentscore", score);

            if (score > PlayerPrefs.GetInt("highscore")) {
                PlayerPrefs.SetInt("highscore", score);
            }

            if (hp == 0) {
                this.killed.Invoke();
                this.gameObject.SetActive(false);
            }

        }

    }

}
