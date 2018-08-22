using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour 
{
	public GUIText txt_click;
	public GUIText txt_anywhere;
	public GUIText txt_to;
	public GUIText txt_start;
	public GUIText txt_high_score;
	
	private float enter_time = 0.2f;
	private float delay      = 0.5f;
	// Use this for initialization
	void Start () 		
	{
		/* podesi velicinu fonta */
		if (Screen.width <1024)
		{
			txt_click.fontSize = 26;
			txt_anywhere.fontSize = 26;
			txt_to.fontSize = 26;
			txt_start.fontSize = 26;
			txt_high_score.fontSize = 26;
		}
		
		txt_high_score.text = "Last score: " + GlobalScript.last_score + "\nTodays high score: " + GlobalScript.high_score;
		Time.timeScale = 1.0f;
		iTween.MoveTo ( txt_click.gameObject,
                        iTween.Hash ( "x", 0.01,
                                      "y", 0.75,	
                                      "time", enter_time,
                                      "delay" , delay)
                                    );			
		iTween.MoveTo ( txt_anywhere.gameObject,
                        iTween.Hash ( "x", 0.01,
                                      "y", 0.65,	
                                      "time", enter_time,
                                      "delay" , enter_time * 2 + delay)
                                    );
		iTween.MoveTo ( txt_to.gameObject,
                        iTween.Hash ( "x", 0.01,
                                      "y", 0.55,	
                                      "time", enter_time,
                                      "delay" , enter_time * 3 + delay)
                                    );
		iTween.MoveTo ( txt_start.gameObject,
                        iTween.Hash ( "x", 0.01,
                                      "y", 0.45,	
                                      "time", enter_time,
                                      "delay" , enter_time * 4 + delay)
                                    );		
		iTween.MoveTo ( txt_high_score.gameObject,
                        iTween.Hash ( "x", 0.01,
                                      "y", 0.22,	
                                      "time", enter_time,
                                      "delay" , enter_time * 5 + delay)
                                    );				
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if ( Input.GetButtonDown ("Fire1"))
		{
			Application.LoadLevel("game");
		}
		
    	if (Input.GetKey(KeyCode.Escape))
    	{
			Time.timeScale = 0.0f;
       		Application.Quit();
    	}		
	}	
}
