using UnityEngine;
using System.Collections;

public class MainLight : MonoBehaviour {

    float timer;
	// Use this for initialization
    public Vector3 targetEulers;
    Vector3 startEulers;
    float targetIntensy = 2.12f;
    float startIntensity;
    public Material Day;
    public Material DayNOCHA;
    public Material Night;
    public Material SkyBoxNioght;
    Light l;
	void Start () 
    {
        l = GetComponent<Light>();
        startEulers = transform.eulerAngles;
        startIntensity= l.intensity;
        Day = RenderSettings.skybox;

    //    dmklasd();
	}

    void dmklasd()
    {
        Day.SetFloat("_SunDisk", SkyBoxNioght.GetFloat("_SunDisk"));
        Day.SetFloat("_SunSize", SkyBoxNioght.GetFloat("_SunSize"));
        Day.SetFloat("_AtmosphereThickness", SkyBoxNioght.GetFloat("_AtmosphereThickness"));
        Day.SetFloat("_Exposure", SkyBoxNioght.GetFloat("_Exposure"));
        Day.SetColor("_SkyTint", SkyBoxNioght.GetColor("_SkyTint"));
        Day.SetColor("_GroundColor", SkyBoxNioght.GetColor("_GroundColor"));

    }
	
	// Update is called once per frame
	void Update () 
    {
        float percentage = Global.Instanse.timer / Global.Instanse.TimeToWin ;
        transform.eulerAngles = Vector3.Lerp(startEulers, targetEulers, percentage);
        l.intensity = Mathf.Lerp(startIntensity, targetIntensy, percentage);

        if (percentage >= 0.95f)
        rendereLerp(percentage);

        if(percentage >= 1)
        {
            Global.Instanse.VoititPelin();
            this.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            Global.Instanse.timer = Global.Instanse.TimeToWin*100;

            Global.Instanse.VoititPelin();
            print("PayToWin");
        }
	}



    void rendereLerp(float percentage)
    {
        Day.SetFloat("_SunDisk", Mathf.Lerp(DayNOCHA.GetFloat("_SunDisk"), Night.GetFloat("_SunDisk"), percentage));
        Day.SetFloat("_SunSize", Mathf.Lerp(DayNOCHA.GetFloat("_SunSize"), Night.GetFloat("_SunSize"), percentage));
        Day.SetFloat("_AtmosphereThickness",( Mathf.Lerp(DayNOCHA.GetFloat("_AtmosphereThickness"), Night.GetFloat("_AtmosphereThickness"), percentage)));
        Day.SetFloat("_Exposure", Mathf.Lerp(DayNOCHA.GetFloat("_Exposure"), Night.GetFloat("_Exposure"), percentage));
        Day.SetColor("_SkyTint", Color.Lerp(DayNOCHA.GetColor("_SkyTint"), Night.GetColor("_SkyTint"), percentage));
        Day.SetColor("_GroundColor", Color.Lerp(DayNOCHA.GetColor("_GroundColor"), Night.GetColor("_GroundColor"), percentage));
    }

}
