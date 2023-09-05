using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{    
    public Rigidbody2D rb; // declara a rigidbody do player;
    public float moveSpeed; // controla a velocidade do personagem;
    private Vector2 moveInput; //Vetor para movimentação do personagem;
    private Vector2 mouseInput;//Vetor para movimentação da câmera do personagem;
    public float mouseSensitivity = 1f; //Sensitividade do Mouse;
    public Transform viewCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimento do player
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));//Atribui as teclas pré programadas de horizontal e vertical para se movimentar em x e y
        Vector3 moveHorizontal = transform.up * -moveInput.x; //cria um vetor de três dimensões para que o player, ao rodar de direção, mude a referência de onde está o lado dele; "-" indica oposto do lado;    
        Vector3 moveVertical = transform.right * moveInput.y; //Idem, para o outro eixo;
        rb.velocity = (moveHorizontal + moveVertical) * moveSpeed; //Set a velocidade do player;
        //movimento do mouse
        mouseInput = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
        viewCam.localRotation = Quaternion.Euler(viewCam.rotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);
        

    }
}