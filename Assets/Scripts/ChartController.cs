﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChartController : MonoBehaviour {

	public RectTransform content;
	public Text hi;
	Text[] texts;
	Text[] acc;
	bool isHi;
	
	void Start () {
		List<Text> temp = new List<Text>();
		List<Text> tempacc = new List<Text>();

		//Filter out the no-word boxes.
		for (int i = 0; i < content.childCount; i++) {
			if (i == 36 || i == 38 || i == 46 || i == 47 || i == 48 || i == 51 || i == 52 || i == 53 || i == 54) {
				content.GetChild(i).GetChild(0).GetComponent<Text>().text = "-";
				content.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
			} else {
				temp.Add(content.GetChild(i).GetChild(0).GetComponent<Text>());
				tempacc.Add(content.GetChild(i).GetChild(1).GetComponent<Text>());
			}
		}

		texts = temp.ToArray();
		acc = tempacc.ToArray();
		SetChars(true);
		hi.text = "Hiragana";
		isHi = true;
	}

	void SetChars(bool hirag) {
		for (int i = 0; i < texts.Length; i++) {
			if (hirag) {
				texts[i].text = MenuController._singleton.charMemory.hirag[i].character + "\n(" + MenuController._singleton.charMemory.romanji[i] + ")";
				if (MenuController._singleton.charMemory.hirag[i].attempts<= 0) {
					acc[i].text = "Acc: -";
				} else {
					acc[i].text = "Acc: " + ((float)MenuController._singleton.charMemory.hirag[i].correct / (float)MenuController._singleton.charMemory.hirag[i].attempts * 100f).ToString("F2") + "%";
				}
			} else {
				texts[i].text = MenuController._singleton.charMemory.kata[i].character + "\n(" + MenuController._singleton.charMemory.romanji[i] + ")";
				if (MenuController._singleton.charMemory.kata[i].attempts <= 0) {
					acc[i].text = "Acc: -";
				} else {
					acc[i].text = "Acc: " + ((float)MenuController._singleton.charMemory.kata[i].correct / (float)MenuController._singleton.charMemory.kata[i].attempts * 100f).ToString("F2") + "%";
				}
			}
		}
	}

	public void ButtToggleHi() {
		isHi = !isHi;
		if (isHi) {
			SetChars(true);
			hi.text = "Hiragana";
		} else {
			SetChars(false);
			hi.text = "Katakana";
		}
	}
}