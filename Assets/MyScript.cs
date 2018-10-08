using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    //variablar
    public SpriteRenderer rend;
    public Color color;
    public float movespeed = 5f;
    public float rotationspeed = 360f;
    public float timer = 0f;
    public float repeating = 1.0f;
    public float cordx = 8;
    public float cordy = 4;
    public float randomspeed;
    public Camera cam;
    public bool pulscolor;
     
    
    // Variablar ovanför som jag använder i koden istället för att använda massa värden.
    void Start()
    {
        InvokeRepeating("Timer", repeating, repeating); //Händer bara varje sekund
        transform.position = new Vector3(Random.Range(-cordx, cordx), Random.Range(-cordy, cordy)); //Skeppet spawnar på en random position när jag startar spelet
        cam = Camera.main;
        randomspeed = Random.Range(3f, 10f); //Gör en variabel för random movespeed så att hastigheten blir random.
        movespeed = randomspeed; //gör så att den randomiserade movespeeden = movespeed
       


    }

    // Update is called once per frame
    void Update()
    {



       transform.Translate(0, movespeed * Time.deltaTime, 0, Space.Self); //inget "if" så att den åker frammåt utan att man trycker i något.

        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(0, 0, -rotationspeed * Time.deltaTime);
            rend.color = Color.blue; //Om man trycker på D så åker den åt höger (-360 grader, som jag använder en variabel för). den blir även blå. .
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationspeed * Time.deltaTime / 2);
            rend.color = Color.green; //Om man trycker på A så åker den åt vänster (360 grader) den blir även grön. delade sedan på 2 så att den åker långsamare åt vänster.
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -movespeed / 2 * Time.deltaTime, 0, Space.Self); //Om man trycker på S så åker den hälften så snabbt. movespeed delat på 2
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rend.color = new Color(Random.Range(0.1f , 1), Random.Range(0.1f , 1), Random.Range(0.1f , 1));
            //Om man trycker på Space så blir det en random färg på skeppet. gjorde så att varje färg går från random 0.1 till 1.
        }
       
   


        }

    private void FixedUpdate()
    {
        if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y); //Om skeppet åker utanför skärmen (utanför kordinaterna som jag har räknat ut på skärmen) så teleporterar den till andra sidan
        }
        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y); //Samma fast åt andra hållet
        }
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5); //Samma fast från upp och ned 
        }
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, -5); //Samma fast åt andra hållet
        }
    }

    void Timer()
    {
        timer += 1;
        Debug.Log(string.Format("Timer: {0}", timer));
        //Jag gör en Debug.Log som gör så att det skrivs ut i konsolen. ekvationen jag använder mig av gör så att variabeln adderas med 1 varje sekund.
    }
}
