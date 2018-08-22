using UnityEngine;
using System.Collections;

public class LevelCreate : MonoBehaviour 
{
	public GameObject plafon;
	public GameObject patos;
	public GameObject zid;
	public GameObject zadnj_zid;
	
	// plafon, patos parametri
	public float orig_patos_y = -6;    // y pozicija plafona
	public float orig_plafon_y = 6;	  // y pozicija patosa	
	float patos_y, plafon_y;
	float x_inc_pat = 22;          // x start pozicija patos
	float x_inc_pla = 22;          // x start pozicija plafon
	float x_inc_off = 1f;          // offset za koji se uvecava pozicija x objekta i za koji se vrsi provera polozaja
	int plafon_counter = 0;
	int patos_counter = 0;	
	
	// zadnji zid
	float x_inc_zzid = 0f;          // x start pozicija zadnji zid
	float x_inc_zzid_off = 45f;         // offset za koji se uvecava pozicija x objekta i za koji se vrsi provera polozaja	
	int zzid_counter = 0;
	
	// zid parametri
	float zid_y       = 8;  // y pozicija zida
	float zid_y_scale = 3;  // u skala zida
	float zid_x_inc   = 50;
	float zid_x_off   = 5;  //5 - 20 ( udaljenost 2 zida )
	
	float zid_x_off_od = 10;
	float zid_x_off_do = 20;
	
	int   zid_counter = 0; // brojac delova zidova koji su trenutno na sceni
	
	void Start () 
	{
		patos_y = orig_patos_y;
		plafon_y = orig_plafon_y;
		
		//MakePatos();
		//MakePlafon();		
		//MakeZadnjiZid();
		//MakeZadnjiZid();
	}
	
	void Update () 
	{
		ProveriPatosPlafon();								
		ProveriZid();		
		ProveriZadnjZid();		
	}
	
	void MakeZid()
	{
		GameObject go;
		
		zid_y  = Random.Range (orig_patos_y, orig_plafon_y);
		
		go = Instantiate(zid, new Vector3(zid_x_inc, zid_y, 0), Quaternion.identity) as GameObject;
		go.transform.position = new Vector3(zid_x_inc, zid_y, 0);			
	    go.transform.tag = "ZID";
		go.transform.localScale =  new Vector3 (1, zid_y_scale, 1);
		
		zid_x_off = Random.Range(zid_x_off_od, zid_x_off_do);
		
		if ( zid_x_off_do <= zid_x_off_od )
			zid_x_off_do = zid_x_off_od;
		else
			zid_x_off_do -= 0.5f;
		
		zid_x_inc += zid_x_off;
		zid_counter ++;		
	}
	
	void ProveriZid()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag("ZID");
		
				
  		foreach (GameObject gov in gos)
		{		
			if ( (gov.transform.position.x - KopterScript.kopter_x) < -zid_x_off * 2)
			{
				Destroy(gov);
				zid_counter --;
			}
		}
		if ( zid_counter < 10)
			MakeZid();		
	}	
	
	void MakePatos ()
	{
		GameObject go;
		
		patos_y = Random.Range (orig_patos_y - 0.2f, orig_patos_y + 0.2f) - 2;				
		
		go = Instantiate(patos, new Vector3(x_inc_pat, patos_y, 0), Quaternion.identity) as GameObject;
		go.transform.position = new Vector3(x_inc_pat, patos_y, 0);			
	    go.transform.tag = "PATOS";
		
		go.transform.localScale =  new Vector3 (1, 4, 10);
		x_inc_pat += x_inc_off;
		
		patos_counter ++;
	}	
	
	void MakePlafon ()
	{
		GameObject go;
		
		plafon_y = Random.Range (orig_plafon_y - 0.2f, orig_plafon_y + 0.2f) + 2;
		
		go = Instantiate(plafon, new Vector3(x_inc_pla, plafon_y, 0), Quaternion.identity) as GameObject;
		go.transform.position = new Vector3(x_inc_pla, plafon_y, 0);
	    go.transform.tag = "PLAFON";
		go.transform.localScale =  new Vector3 (1, 4, 10);
		x_inc_pla += x_inc_off;
		
		plafon_counter ++;
	}
	
	void MakeZadnjiZid ()
	{
		GameObject go;				
		go = Instantiate(zadnj_zid, new Vector3(x_inc_zzid, 0, 3), Quaternion.identity) as GameObject;
		go.transform.position = new Vector3(x_inc_zzid, 0, 3);			
	    go.transform.tag = "ZADNJI_ZID";		
		x_inc_zzid += x_inc_zzid_off;		
		
		zzid_counter ++;
		
	}	
	
	void ProveriZadnjZid()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag("ZADNJI_ZID");
		
  		foreach (GameObject gov in gos)
		{			
			if ( (gov.transform.position.x - KopterScript.kopter_x) < -x_inc_zzid_off  )
			{
				Destroy(gov);
				zzid_counter --;
				//MakeZadnjiZid();
			}			
		}		
		if (zzid_counter < 3)
			MakeZadnjiZid();						
		
		
		
	}
	
	void ProveriPatosPlafon()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag("PATOS");
		
  		foreach (GameObject gov in gos)
		{
			if ( (gov.transform.position.x - KopterScript.kopter_x) < -x_inc_off * 14 ) //9
			{
				Destroy(gov);
				patos_counter --;
			}
		}
		
		if (patos_counter < 40) //29
			MakePatos();			
		
		GameObject[] gos2 = GameObject.FindGameObjectsWithTag("PLAFON");
		
  		foreach (GameObject gov in gos2)
		{
			if ( (gov.transform.position.x - KopterScript.kopter_x) < -x_inc_off * 14)
			{
				Destroy(gov);
				plafon_counter --;
			}
		}		
		
		if (plafon_counter < 40)
			MakePlafon();				
	}
}
