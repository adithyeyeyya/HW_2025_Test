using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        // Read speed from JSON or default to 5
        if (ConfigLoader.Instance != null && ConfigLoader.Instance.config != null)
             speed = ConfigLoader.Instance.config.player_data.speed;
        else speed = 5f;
    }

    void Update() {
        // STOP if game is not active
        if (GameManager.Instance == null || !GameManager.Instance.isGameActive) return;

        // --- MOVEMENT ---
        float h = 0;
        float v = 0;

        if (Keyboard.current != null) {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) h = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) h = 1;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) v = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) v = -1;
        }

        Vector3 movement = new Vector3(h, 0, v) * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // --- DEATH CHECK ---
        if (transform.position.y < -2) {
            GameManager.Instance.GameOver(); // Call the UI Manager instead of reloading
        }
    }
}