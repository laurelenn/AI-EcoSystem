﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class GeneticAlgorithmManager : MonoBehaviour {
    [Header("Genetic Algorithm")]
	[SerializeField] string targetString = "00110010111110100110010";
	[SerializeField] string validCharacters = "01";
	[SerializeField] int populationSize = 200;
	[SerializeField] float mutationRate = 0.01f;
	[SerializeField] int elitism = 5;

	[Header("Other")]
	[SerializeField] int numCharsPerText = 15000;
	[SerializeField] Text targetText;
	[SerializeField] Text bestText;
	[SerializeField] Text bestFitnessText;
	[SerializeField] Text numGenerationsText;
	[SerializeField] Transform populationTextParent;
	[SerializeField] Text textPrefab;
	public List<GameObject> allPlants;

	private GeneticAlgorithm<char> ga;
	private System.Random random;

	void Start()
	{
		targetText.text = targetString;

		if (string.IsNullOrEmpty(targetString))
		{
			Debug.LogError("Target string is null or empty");
			this.enabled = false;
		}

		random = new System.Random();
		ga = new GeneticAlgorithm<char>(populationSize, targetString.Length, random, GetRandomCharacter, FitnessFunction, elitism, mutationRate);
	}

	void Update()
	{
		ga.NewGeneration();

		UpdateText(ga.BestGenes, ga.BestFitness, ga.Generation, ga.Population.Count, (j) => ga.Population[j].Genes);

		if (ga.BestFitness == 1)
		{
			this.enabled = false;
		}
	}

	private char GetRandomCharacter()
	{
		int i = random.Next(validCharacters.Length);
		return validCharacters[i];
	}

	private float FitnessFunction(int index)
	{
		float score = 0;
		DNA<char> dna = ga.Population[index];

		for (int i = 0; i < dna.Genes.Length; i++)
		{
			if (dna.Genes[i] == targetString[i])
			{
				score += 1;
			}
		}

		score /= targetString.Length;

		score = (Mathf.Pow(2, score) - 1) / (2 - 1);

		return score;
	}

	private bool killClosePlant(int index) {
		foreach (var plant in allPlants)
		{
			//to do
		}
		
		return true;
	}














	private int numCharsPerTextObj;
	private List<Text> textList = new List<Text>();

	void Awake()
	{
		numCharsPerTextObj = numCharsPerText / validCharacters.Length;
		if (numCharsPerTextObj > populationSize) numCharsPerTextObj = populationSize;

		int numTextObjects = Mathf.CeilToInt((float)populationSize / numCharsPerTextObj);

		for (int i = 0; i < numTextObjects; i++)
		{
			textList.Add(Instantiate(textPrefab, populationTextParent));
		}
	}

	private void UpdateText(char[] bestGenes, float bestFitness, int generation, int populationSize, Func<int, char[]> getGenes)
	{
		bestText.text = CharArrayToString(bestGenes);
		bestFitnessText.text = bestFitness.ToString();

		numGenerationsText.text = generation.ToString();

		for (int i = 0; i < textList.Count; i++)
		{
			var sb = new StringBuilder();
			int endIndex = i == textList.Count - 1 ? populationSize : (i + 1) * numCharsPerTextObj;
			for (int j = i * numCharsPerTextObj; j < endIndex; j++)
			{
				foreach (var c in getGenes(j))
				{
					sb.Append(c);
				}
				if (j < endIndex - 1) sb.AppendLine();
			}

			textList[i].text = sb.ToString();
			Plant plant = new Plant(bestGenes);
			plant.PlantBuilder();
			allPlants.Add(plant.PlantBuilder());
		}
	}

	private string CharArrayToString(char[] charArray)
	{
		var sb = new StringBuilder();
		foreach (var c in charArray)
		{
			sb.Append(c);
		}

		return sb.ToString();
	}
}