using UnityEngine;

public class Rain : MonoBehaviour
{
    private int _type;
    float _size;
    int _score;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        _type = Random.Range(1, 5);

        if (_type == 1)
        {
            _size = 1.2f;
            _score = 3;
            GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (_type == 2)
        {
            _size = 1.0f;
            _score = 2;
            GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 255 / 255f);
        }
        else if (_type == 3)
        {
            _size = 0.8f;
            _score = -5;
            GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
        }
        else
        {
            _size = 0.8f;
            _score = 1;
            GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 255 / 255f);
        }

        transform.localScale = new Vector3(_size, _size, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            //Debug.Log("∂•¿Ã¥Ÿ!");
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "rtan")
        {
            GameManager.Instance.AddScore(_score);
            Destroy(gameObject);
            //Debug.Log(score);
        }
    }
}
