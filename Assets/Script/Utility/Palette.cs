﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour {

	Color[] colorPalette = new Color[6];

	/**
	 * generate a new palette with the giveng lenght
	 */
	public void GeneratePalette(int len) {

		colorPalette = new Color[len];

		for (int i = 0; i < len; i++) {
			//pick a random color from different croma scales
			Color nc = new Color (1, Random.Range (0f, 1f), Random.Range (0f, 1f), 1);

			if (i % 2 == 0) {
				nc = new Color (Random.Range (0f, 1f), 1, Random.Range (0f, 1f), 1);
			}
			
			if (i%3 == 0) {
				nc = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), 1, 1);
			}

			colorPalette [i] = nc;
		}
	}

	public Color GetZeroColor(){
		return colorPalette [0];
	}

	/**
	 * pick a random color from the pre-generated palette
	 */
	public Color GetRandomColor(){
		return colorPalette [Random.Range (0, colorPalette.Length)];
	}

	/**
	 * get the lenght of the pre-generated palette
	 */
	public int GetPaletteLenght(){
		return colorPalette.Length;
	}

	/**
	 * change the color of the given sprite renderer with the next of the color in the pre-generated palette
	 */
	public void Next(SpriteRenderer spr){

		bool found = false;

		int j = 0;

		for (int i = 0; i < colorPalette.Length; i++) {
			if (!found) {
				if (Color.Equals(spr.color, colorPalette [i])) {
					j = i;
					found = true;
				}
			}
		}

		if (j == colorPalette.Length - 1) {
			spr.color = colorPalette [0];
		} else {
			spr.color = colorPalette [j + 1];
		}

		if (!found)
			spr.color = colorPalette [0];

	}

	/**
	 * change the color of the given sprite renderer with the previous of the color in the pre-generated palette
	 */
	public void Previous(SpriteRenderer spr){

		bool found = false;

		int j = 0;

		for (int i = 0; i < colorPalette.Length; i++) {
			if (!found) {
				if (Color.Equals(spr.color, colorPalette [i])) {
					j = i;
					found = true;
				}
			}
		}

		if (j == 0) {
			spr.color = colorPalette [colorPalette.Length - 1];
		} else {
			spr.color = colorPalette [j - 1];
		}

		if (!found)
			spr.color = colorPalette [0];
		
	}

}
