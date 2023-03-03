using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public Transform playerTransform;
    public Transform RatTransform;
    public float timer = 0f;
    public float timerRec =0f;
    public TMP_Text textoTiempo;
    public TMP_Text textoTiempoRec;
    private bool trigger;
    public float fallSpeed = 1.0f;

    void Start()
    {
        trigger = true;
    }

    void Update()
    {
        if (playerTransform.position.x > -2.0 && playerTransform.position.x < 2.0)
        {
            if (RatTransform.position.y < playerTransform.position.y)
            {
                // Verificar si se está pulsando a o d y ajustar la velocidad de caída
                if (Input.GetKey(KeyCode.A))
                {
                    fallSpeed = -1f; // disminuir velocidad de caída
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    fallSpeed = -1f;// aumentar velocidad de caída
                }
                else
                {
                    fallSpeed = 1.0f; // velocidad de caída predeterminada
                }

                if (trigger)
                {
                    timer = 0;
                }
                trigger = false;
                timer += Time.deltaTime;
                TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
                string timeText = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Seconds, timeSpan.Milliseconds / 10, timeSpan.Milliseconds % 10);
                textoTiempo.text = timeText;

                if (timer > timerRec)
                {
                    timerRec = timer;
                    string timeTextRec = string.Format("{0:00}:{1:00}:{2:00}", timeSpan.Seconds, timeSpan.Milliseconds / 10, timeSpan.Milliseconds % 10);
                    textoTiempoRec.text = timeTextRec;
                }

                // Actualizar la posición del personaje con la velocidad de caída ajustada
                Vector3 fall = new Vector3(0, -fallSpeed, 0);
                playerTransform.position += fall * Time.deltaTime;
            }
        }

        if (playerTransform.position.x < -2.5 || playerTransform.position.x > 2.5) { trigger = true; }
        



    }

}
