using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public float fatorDeCrescimento = 1f;
        void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            transform.localScale += Vector3.one * fatorDeCrescimento;
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winTextObject.SetActive(true);
        }
    }
}