using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Trey Klotz
 * Date: 12/13/2020
 * Description: handles player movement, collision, and monitors fruit pickups
 */

public class PlayerController : MonoBehaviour
{
    public Text fruitScore;
    public Text gameOverText;
    public AudioClip chomp;

    private float playerSpeed;
    private float jumpHeight;
    private Rigidbody player;
    private bool gameStart;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        playerSpeed = 5.5f;
        jumpHeight = 1.65f;
        player = GetComponent<Rigidbody>();
        gameStart = false;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart) {
            //move the player
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            player.MovePosition(player.transform.position + move.normalized * Time.deltaTime * playerSpeed);

            //allow the player to jump
            if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("jump");
                player.AddForce(new Vector3(0, 2, 0) * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }

            //if the player falls off the platform, game is over
            if (player.position.y < -2)
                gameOver();

        }

        //wait for the player to fall for a few seconds, then restart the game
        if (player.position.y < -90) UnityEngine.SceneManagement.SceneManager.LoadScene("Mazefal");
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;

        if (collision.gameObject.CompareTag("apple")) {
            //1 point
            Debug.Log("apple pick up");
            AudioSource.PlayClipAtPoint(chomp, player.position);
            int score = System.Convert.ToInt32(fruitScore.text.ToString());
            score += 1;
            fruitScore.text = score.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("cherry")) {
            //2 points
            Debug.Log("cherry pick up");
            AudioSource.PlayClipAtPoint(chomp, player.position);
            int score = System.Convert.ToInt32(fruitScore.text.ToString());
            score += 2;
            fruitScore.text = score.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("strawberry")) {
            //3 points
            Debug.Log("strawberry pick up");
            AudioSource.PlayClipAtPoint(chomp, player.position);
            int score = System.Convert.ToInt32(fruitScore.text.ToString());
            score += 3;
            fruitScore.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void gameOver() {
        Debug.Log("game over");
        gameOverText.gameObject.SetActive(true);
    }

    public void startGame() {
        Debug.Log("game start");
        gameStart = true;
    }
}
