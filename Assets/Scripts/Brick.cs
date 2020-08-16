using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else
        {
            Debug.LogError("Brick sprite missing.");
        }
    }

    // TODO: Remove this method once we actually win!
    void SimulateWin()
    {
        levelManager.LoadNextSceneAsync();
    }
}
