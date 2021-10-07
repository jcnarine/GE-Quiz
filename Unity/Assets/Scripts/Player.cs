using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : Spaceship
	{

	public int bounce;
	public TextMeshProUGUI livesText;

	// Update is called once per frame
	public void Update()
		{
		if (Input.GetKeyDown(KeyCode.Space) && canShoot)
			{
			Shoot();
			}
		}

	public void FixedUpdate()
		{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
			rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
			rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
			rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
			}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
			rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
			}

		Vector3 temp = rb.velocity;

		if (temp.sqrMagnitude > sqrMaxVelocity)
			{
			rb.velocity = temp.normalized * maxVelocity;
			}
		}
	public void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.tag == "Asteroid"|| other.gameObject.tag == "Enemy")
			{
			lives -= 1;
			if (lives==0) {
				SceneManager.LoadScene("YouLose");
				}
			livesText.text = "Lives: " + lives;
			}
		if (other.gameObject.tag == "Boundary")
			{
			rb.AddForce(rb.velocity * -1 * bounce, ForceMode.Impulse);
			}
		}
	}
