using UnityEngine;
using System.Collections;

public class KopterScript : MonoBehaviour 
{
	public float up_force = 30;   // snaga potiska 
	public float speed = 10;      // brzina kretanja na desno
	//public float ship_rotation_speed = 50; // brzina rotiranja oko uzduzne ose
	public GameObject camera;	 
	
	public static float kopter_x; // za pristup spolja udaljenosti
	public static bool game_over = false;	
	
	public GameObject exp;
	
	public AudioClip engine_clip; // zvuk ispaljivanja motora
	public AudioClip bomb;        // zvuk krshenja	
	
	AudioSource[] x;
		
	/* ZA ZVUK
	 * - dodati onoliko AudioSource koliko ima zvukova
	 * - u Start() ih izbrojati i svakom od njih dodeliti audio klip, sve to smestiti u neki AudioS niz
	 * - pustati ih po potrebi
	 * - klipove audiosorsu mogu dodati i u Editoru
	 * */
	
	/* PAZNJA
	 * pri novom ucitavanju nivoa ulazna tacka je Start() funkcija, bez inicijalizacije */
	void Start () 
	{
		game_over = false;
		
		GetComponent<Rigidbody>().AddForce (new Vector3 (0, 12, 0), ForceMode.Impulse );		

		x = GetComponents<AudioSource>();
		x[0].clip = engine_clip;		
		x[1].clip = bomb;
	}
	
	void Update () 
	{		
		/* PAZNJA!
		 * importovani model ima obrnute ose, stoga Unitijevo desno nije modelovo desno
		 * vec modelovo gore
		 * */
		
		//transform.rotation = Quaternion.Euler(0, i, 270 + rigidbody.velocity.y * 2);		
		//transform.Rotate(  new Vector3(0, 3, 0));
		
		kopter_x = GetComponent<Rigidbody>().transform.position.x;
		// dodaj silu na gore na click ili touch, relativno na WORLD
		if ( Input.GetButton ("Fire1") && !game_over)
		{
			/* dodaj silu na gore */
			GetComponent<Rigidbody>().AddForce( Vector3.up * up_force * Time.deltaTime * 100); 
			
			/* pusti zvuk */
			if (!x[0].isPlaying)
				x[0].Play();
			
			/* ispali motor ENGINE iz child komponente */
			transform.Find("Engine").GetComponent<ParticleEmitter>().maxEnergy = 0.2f;
		}
		else
		{
			/* ugasi motor i zvuk */
			x[0].Stop();					
			transform.Find("Engine").GetComponent<ParticleEmitter>().maxEnergy = 0.1f;
		}
		
		/* rotiraj helikopter u zavisnosti id y brzine */
		if (GetComponent<Rigidbody>().velocity.y > 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 270 + GetComponent<Rigidbody>().velocity.y * 2);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 0, 270 + GetComponent<Rigidbody>().velocity.y * 2);
		}
		
		/* pomeri kameru i helikopter u desno, i to relativno u odnosu na WORLD */
		transform.Translate ( Vector3.right * Time.deltaTime * speed, Space.World);
		
		camera.transform.Translate ( Vector3.right * Time.deltaTime * speed);		
		
		speed += 0.001f;			
	}
	
	void OnCollisionEnter ( Collision collision )
	{
		if ( collision.gameObject.tag == "PATOS" ||
			 collision.gameObject.tag == "PATOSX" || 
			 collision.gameObject.tag == "PLAFON" ||
			 collision.gameObject.tag == "PLAFONX" || 
			 collision.gameObject.tag == "ZID" )
		{
			/*
			audio.clip = bomb;
			if (!audio.isPlaying)
				audio.Play();
				*/
			x[1].Play();
			game_over = true;			
		}
	}	
	
}
