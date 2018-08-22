using UnityEngine;
using System.Collections;

public class GlobalScript : MonoBehaviour 
{	
	public GUIText txt_score;
	public GUIText txt_high_score;
	public GUIText txt_game_over;
	public GUIText txt_achievement;
	public GUIText txt_start;	
	
	public static float high_score = 0;
	public static float last_score = 0;
	
	private float txt_x = 0.4f; // sredina natpisa za acivments

	float distance = 0;
	
	public AudioClip crash;
	public AudioClip woosh_in, woosh_out;
	AudioSource[] x;
	
	short klik = 0; // brojac klikova, radi restarta kod game over
	
	void Start()
	{
	    txt_achievement.material.color = Color.green;
		/* podesi font za razne rezolucije */
		if (Screen.width <1024)
		{
			txt_score.fontSize = 26;
			txt_high_score.fontSize = 26;
		}
		
		x = GetComponents<AudioSource>();
		x[1].clip = woosh_in;
		x[2].clip = woosh_out;		
	}
	void Update () 
	{
    	if (Input.GetKey(KeyCode.Escape))
    	{
			Time.timeScale = 0.0f;		
       		Application.LoadLevel("start");
			Time.timeScale = 1.0f;
    	}
		
		distance = Mathf.Round( KopterScript.kopter_x);		 // ili podeljeno sa 2?
		txt_score.text = "Distance: " + distance;
		
		txt_high_score.text = "High score: " + GlobalScript.high_score;		
		
		if ( distance > GlobalScript.high_score )
		{
			GlobalScript.high_score = distance;
		}		
		
		if ( KopterScript.game_over )
		{
			last_score = distance;
			txt_achievement.text = "";
			txt_game_over.text = "GAME OVER";
			GetComponent<AudioSource>().Stop();
			Time.timeScale = 0.0f;		
			if ( Input.GetButtonDown ("Fire1"))
			{
				klik++;
				if (klik==2)
				{
					Time.timeScale = 1.0f;
					Application.LoadLevel("start");
					//KopterScript.game_over = false;
					klik = 0;
				}
				
							
			}

		}
		else
		{
			txt_game_over.text = "";
		}
		
		//DisplayAchi_DEBUG();
		DisplayAchi();		
	}	
	
	/*
	AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
	{
		//Object newAudio = gameObject.AddComponent.
  		newAudio.clip = clip;
  		newAudio.loop = loop;
  		newAudio.playOnAwake = playAwake;
  		newAudio.volume = vol;
  		return newAudio;
}	*/
	
    void DisplayAchi()
	{
		if (distance==100)
		{			
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "100 points!\nGood!";
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}
		if (distance==250)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "250 points!\nNice!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		if (distance==500)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "500 points!\nYeah!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}
		if (distance==750)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "750 points!\nGo, go, go!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}				
		if (distance==1000)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "1000 points!\nIncredible!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		if (distance==1500)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "1500 points!\nFantastic!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}				
		if (distance==2000)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "2000 points!\nImpossible!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		
		if (distance==2500)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "2500 points!\nGreen!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}			
		
		if (distance==3000)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "3000 points!\nSuper Green!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}				
		
		if (distance==3500)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "3500 points!\nWTF?!?!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}			
		
		if (distance==4000)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "4000 points!\nMy high score is ~1000!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		if (distance==4500)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "4500 points!\nIsland";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		
		if (distance==5000)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "4500 points!\nSweden";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
	}
		
    void DisplayAchi_DEBUG()
	{
		if (distance==50)
		{
			if (!x[1].isPlaying)
				x[1].Play();
			txt_achievement.text = "100 points!\nGood!";
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}
		if (distance==100)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "250 points!\nNice!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		if (distance==150)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "500 points!\nYeah!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}
		if (distance==200)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "1000 points!\nIncredible!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		if (distance==250)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "1500 points!\nFantastic!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}				
		if (distance==300)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "2000 points!\nImpossible!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		
		if (distance==350)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "2500 points!\nGreen!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}			
		
		if (distance==400)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "3000 points!\nSuper Green!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}				
		
		if (distance==3500)
		{
			if (!x[1].isPlaying)
				x[1].Play();			
			txt_achievement.text = "3500 points!\nWTF?!?!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}			
		
		if (distance==4000)
		{
			txt_achievement.text = "4000 points!\nMy high score is ~1000!";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		if (distance==4500)
		{
			txt_achievement.text = "4500 points!\nIsland";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
		
		if (distance==5000)
		{
			txt_achievement.text = "4500 points!\nSweden";
			txt_achievement.transform.position = new Vector3(1,0.35f,0);
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", txt_x,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 0)
			              );
			iTween.MoveTo ( txt_achievement.gameObject,
			                iTween.Hash ( "x", -1,
				                          "y", 0.35f,
			                              "time", 0.5,
			                              "delay" , 2)
			              );			
		}		
	}	
}