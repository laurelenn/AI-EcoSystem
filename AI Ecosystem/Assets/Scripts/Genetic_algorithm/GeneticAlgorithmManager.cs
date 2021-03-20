using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class GeneticAlgorithmManager : MonoBehaviour {
	private string targetString;

    [Header("Genetic Algorithm")]
	// [SerializeField] string targetString = "00110010111110100110010";
	[SerializeField] string validCharacters = "01";
	[SerializeField] int populationSize = 10;
	[SerializeField] float mutationRate = 0.01f;
	[SerializeField] int elitism = 5;

	FiguierBuilder figuierBuilder;
	AvocadoBuilder avocadoBuilder;

	// [Header("Other")]
	// [SerializeField] int numCharsPerText = 15000;
	// [SerializeField] Text targetText;
	// [SerializeField] Text bestText;
	// [SerializeField] Text bestFitnessText;
	// [SerializeField] Text numGenerationsText;
	// [SerializeField] Transform populationTextParent;
	// [SerializeField] Text textPrefab;
	public List<GameObject> allPlants;

	private GeneticAlgorithm<char> ga;
	private System.Random random;
	private float cooldown = 0f;

	private List<int> markedToKill = new List<int>();

	void Start()
	{
		targetString = gameObject.GetComponent<Climat>().AttributeToBit();
		// targetText.text = targetString;
		GameObject manager = GameObject.FindGameObjectWithTag("Manager");
		figuierBuilder = manager.GetComponent<FiguierBuilder>();
		avocadoBuilder = manager.GetComponent<AvocadoBuilder>();

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
		cooldown -= Time.deltaTime;
		if(cooldown <= 0) {
			ga.NewGeneration();

			// UpdateText(ga.BestGenes, ga.BestFitness, ga.Generation, ga.Population.Count, (j) => ga.Population[j].Genes);
			allPlants.Clear();
			markedToKill.Clear();
			CreatePlants();
			MarkPlants();
			KillMarkedPlants();

			cooldown = 1;
		}

		// if (ga.BestFitness == 1)
		// {
		// 	this.enabled = false;
		// }
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


	private void CreatePlants() {
		//create plant gameobject for each DNA sequence
		for (int i = 0; i < ga.Population.Count; i++)
		{
			Plant plant = new Plant(ga.Population[i].Genes);
			allPlants.Add(plant.PlantBuilder(figuierBuilder, avocadoBuilder));
		}
	}
	private bool MarkPlants() {
		for(int i=0; i<allPlants.Count; ++i)
		{
			for(int j=0; j<allPlants.Count; ++j) {
				if(i!=j) {
					if(!markedToKill.Contains(i)) { //evoid duplicates
						float distance = Vector3.Distance(allPlants[i].transform.position, allPlants[j].transform.position);
						if(distance < allPlants[i].GetComponent<PlantInfo>().plant.space) {
							MarkWeakerPlant(i, j);
						}
					}
				}
			}
		}
		
		return true;
	}

	private void MarkWeakerPlant(int index1, int index2) {
		float fitness1 = FitnessFunction(index1);
		float fitness2 = FitnessFunction(index2);

		if(fitness1 > fitness2) {
			markedToKill.Add(index2);
		}
		else {
			markedToKill.Add(index1);
		}
	}

	private void KillMarkedPlants() {
		markedToKill.Sort();
		for (int i = markedToKill.Count-1; i > 0; --i)
		{
			int index = markedToKill[i];
			Destroy(allPlants[index]);
			ga.Population.RemoveAt(index);
		}
	}

// TODO
// regarder fonctionnement liste, faire en sorte que la population puisse s'aggrandir DONE ?
// faire en sorte que certaines plantes meurent à chaque génération DONE ?
// voir pour le placement des plantes sur la plane TODO

	public void setTargetString(string target) {
		targetString = target;
	}









	private int numCharsPerTextObj;
	private List<Text> textList = new List<Text>();

// 	void Awake()
// 	{
// 		numCharsPerTextObj = numCharsPerText / validCharacters.Length;
// 		if (numCharsPerTextObj > populationSize) numCharsPerTextObj = populationSize;

// 		int numTextObjects = Mathf.CeilToInt((float)populationSize / numCharsPerTextObj);

// 		for (int i = 0; i < numTextObjects; i++)
// 		{
// 			textList.Add(Instantiate(textPrefab, populationTextParent));
// 		}
// 	}

// 	private void UpdateText(char[] bestGenes, float bestFitness, int generation, int populationSize, Func<int, char[]> getGenes)
// 	{
// 		bestText.text = CharArrayToString(bestGenes);
// 		bestFitnessText.text = bestFitness.ToString();

// 		numGenerationsText.text = generation.ToString();

// 		for (int i = 0; i < textList.Count; i++)
// 		{
// 			var sb = new StringBuilder();
// 			int endIndex = i == textList.Count - 1 ? populationSize : (i + 1) * numCharsPerTextObj;
// 			for (int j = i * numCharsPerTextObj; j < endIndex; j++)
// 			{
// 				foreach (var c in getGenes(j))
// 				{
// 					sb.Append(c);
// 				}
// 				if (j < endIndex - 1) sb.AppendLine();
// 			}

// 			textList[i].text = sb.ToString();
// 			// Plant plant = new Plant(bestGenes);
// 			// plant.PlantBuilder();
// 			// allPlants.Add(plant.PlantBuilder());
// 		}
// 	}

// 	private string CharArrayToString(char[] charArray)
// 	{
// 		var sb = new StringBuilder();
// 		foreach (var c in charArray)
// 		{
// 			sb.Append(c);
// 		}

// 		return sb.ToString();
// 	}
}
