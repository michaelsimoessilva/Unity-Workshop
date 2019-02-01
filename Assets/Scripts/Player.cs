using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColor;

    public Manager manager;
	//public Color colorCyan;
	//public Color colorYellow;
	//public Color colorMagenta;
	//public Color colorPink;

    public Color[] colors;

	void Start ()
	{
		SetRandomColor();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;

            rb.velocity = Vector2.up * jumpForce;
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(col.gameObject);
            manager.CreateObstacles();

            return;
		}

		if (col.tag != currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				break;
			case 1:
				currentColor = "Yellow";
				break;
			case 2:
				currentColor = "Magenta";
				break;
			case 3:
				currentColor = "Pink";
				break;
		}

        sr.color = colors[index];
    }
}
