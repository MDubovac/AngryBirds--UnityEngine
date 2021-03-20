using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLauched;
    private float _timeWaiting;
    
    [SerializeField]
    private float _launchPower;

    private void Awake() 
    {
        _initialPosition = transform.position; 
    }

    public void Update() 
    {   
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);

        if(_birdWasLauched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeWaiting += Time.deltaTime;
        }

        if(transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -20 || _timeWaiting > 3) 
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    private void OnMouseDown() 
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp() 
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;

        _birdWasLauched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() 
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }  
}
