using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsynchronousLevelLoad : MonoBehaviour
{
	public Log log;

	void Start()
	{
		log.AddLine("Start loading level");
		StartCoroutine(LoadLevel("TestLevel"));
	}

	IEnumerator LoadLevel(string level)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		AsyncOperation loader = SceneManager.LoadSceneAsync(level);
		loader.allowSceneActivation = false;
		while (loader.progress < 0.9f)
		{
			stopwatch.Start();
			yield return null;
			stopwatch.Stop();
			log.AddLine(string.Format("Loading frame took {0} seconds", stopwatch.Elapsed));
			stopwatch.Reset();
		}
		log.AddLine("Level load complete");
	}
}
