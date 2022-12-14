using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FakeBossFight : MonoBehaviour
{
    
    public FakeBoss[] prefabs;

    public int rows = 1;
    public int columns = 1;
    
    private float timer;
    private int timescore;

    public float spacing = 35.0f; // Add new variable spacing
    public float speed = 0.1f;

    public Projectile missilePrefab;
    public float missileAttackRate = 1.0f;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI ScoreText;

    public int totalInvaders => this.rows * this.columns;
    public int amountKilled { get; private set; }
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;

    private Vector3 _direction = Vector2.right;

    private void Awake() {

        Reset();

        for (int row = 0; row < this.rows; row++) {
            
            float width = spacing * (this.columns - 1);
            float height = spacing * (this.rows - 1);

            Vector3 centering = new Vector2(-width / 2, -height / 2); 
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * spacing), 0.0f);

            for (int col = 0; col < this.columns; col++) {

                FakeBoss invader = Instantiate(this.prefabs[row], this.transform);
                invader.killed += InvaderKilled;

                Vector3 position = rowPosition;
                position.x += col * spacing;
                invader.transform.localPosition = position;

            }
        }
    }

    private void Start() {

        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);
        HPText.text = "HP : " + PlayerPrefs.GetInt("hp");
    }

    private void Update() {

        this.transform.position += _direction * (this.speed) * Time.deltaTime;
        speed = speed + 0.0001f;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform) {

            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f)) {
                AdvanceRow();
            } else if (_direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f)) {
                AdvanceRow();
            }
        }

        timer += Time.deltaTime;

        if (timer > 4f) {

            timescore += 10;
            
            //Reset the timer to 0.
            timer = 0;
        }

        HPText.text = "HP : " + PlayerPrefs.GetInt("hp");
        ScoreText.text = "Score : " + (PlayerPrefs.GetInt("currentscore")-timescore);
        
    }

    private void Reset() {

        Vector3 position = this.transform.position;
        position.y = 3.759784f;
        position.x = 0f;
        this.transform.position = position;        
        this.amountKilled = 0;

    }

    private void AdvanceRow() {

        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;

    }

    private void MissileAttack() {

        foreach (Transform invader in this.transform) {

            if (!invader.gameObject.activeInHierarchy) {
                continue;
            }

            if (Random.value < (1.0f / (float)this.amountAlive)) {
                Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                break;
            }

        }

    }

    private void InvaderKilled() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);

    }

}
