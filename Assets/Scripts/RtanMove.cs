using UnityEngine;

public class RtanMove : MonoBehaviour
{
    private float _direction = 0.05f;
    private float _toward = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _toward *= -1;
            _direction *= -1;
        }

        if (transform.position.x > 2.8f)
        {
            _direction = -0.05f;
            _toward = -1.0f;
        }

        if (transform.position.x < -2.8f)
        {
            _direction = 0.05f;
            _toward = 1.0f;
        }

        transform.localScale = new Vector3(_toward, 1, 1);
        transform.position += new Vector3(_direction, 0, 0);
    }
}
