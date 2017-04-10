using UnityEngine;
using System.Collections.Generic;
using System.Xml;


namespace Com.IsartDigital.BeTheBastard.Scripts.Managers.NonPhysicsManager.Audio.SFX
{


[System.Serializable]
public class MyAudioClip
{
	public MyAudioClip(AudioClip clip,float volume)
	{
		this.clip = clip;
		this.volume = volume;
	}

	public AudioClip clip;
	public float volume;
}

/// <summary>
/// Sfx manager.
/// Gestion de SFX
/// </summary>
public class SfxManager<T> : BaseManager<T> where T : Component
    {

	public TextAsset sfxXmlSetup;
	public string resourcesFolderName;

	public int nAudioSources = 2;

	public bool shouldShowGui;

	List<AudioSource> audioSources = new List<AudioSource>();
	Dictionary<string,MyAudioClip> dicoAudioClips = new Dictionary<string, MyAudioClip>();



        virtual protected void OnDestroy()
        {
            
        }

	virtual protected AudioSource AddAudioSource()
	{
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSources.Add(audioSource);
		
		audioSource.loop = false;
		audioSource.playOnAwake = false;

		return audioSource;
	}

	// Use this for initialization
	virtual protected void Start () {

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(sfxXmlSetup.text);

		foreach(XmlNode node in xmlDoc.GetElementsByTagName("SFX"))
		{
			if(node.NodeType!= XmlNodeType.Comment)

			dicoAudioClips.Add(
				node.Attributes["name"].Value,
			    new MyAudioClip(
				(AudioClip)Resources.Load(resourcesFolderName+"/"+node.Attributes["name"].Value,typeof(AudioClip)),
				float.Parse(node.Attributes["volume"].Value)));
		}

		for (int i = 0; i < nAudioSources; i++) 
			AddAudioSource();

            
        }

	virtual public void PlaySfx(string sfxName)
	{
		if(FlagsManager.manager && !FlagsManager.manager.GetFlag("SETTINGS_SFX",true))
			return;

		MyAudioClip audioClip;
		if(!dicoAudioClips.TryGetValue(sfxName,out audioClip))
		{
			Debug.LogError("SFX, no audio clip with name: "+sfxName);
			return;
		}

		AudioSource audioSource = audioSources.Find(item=>!item.isPlaying);
		if(audioSource) 
			audioSource.PlayOneShot(audioClip.clip,audioClip.volume);

	}

       

        


        virtual protected void OnGUI()
	{
		if(!shouldShowGui) return;


		GUILayout.BeginArea(new Rect(Screen.width*.5f,10,200,Screen.height));
		GUILayout.Label("SFX MANAGER");
		GUILayout.Space(20);
		foreach (var item in dicoAudioClips) {
			if(GUILayout.Button("PLAY "+item.Key))
				PlaySfx(item.Key);
		}
		GUILayout.EndArea();
		
	}

}

}
