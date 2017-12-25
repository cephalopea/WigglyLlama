using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (int sceneToChangeTo)
    {
       // Application.LoadLevel(sceneToChangeTo);
		SceneManager.LoadScene (sceneToChangeTo);
    }
		
	} 
