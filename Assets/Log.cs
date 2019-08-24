using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour {

	public int maxLines = 24;
	Text log;
	Queue<string> lines = new Queue<string>();

	void Awake () {
		log = GetComponent<Text>();
		for (int i = 0; i < maxLines; ++i)
		{
			lines.Enqueue("");
		}
	}

	public void AddLine(string line)
	{
		lines.Dequeue();
		lines.Enqueue(line);
		StringBuilder logBuilder = new StringBuilder();
		foreach (string row in lines)
		{
			logBuilder.AppendLine(row);
		}
		log.text = logBuilder.ToString();
	}
}
