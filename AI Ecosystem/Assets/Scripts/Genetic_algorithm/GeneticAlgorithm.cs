﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Kryzarel youtube tutorial
public class GeneticAlgorithm<T> {
    public List<DNA<T>> Population {get; private set;}
    public int Generation {get; private set;}
    public float BestFitness{get; private set;}
    public T[] BestGenes {get; private set;}

    public int Elitism;
    public float MutationRate;
    private List<DNA<T>> newPopulation;

    private System.Random random;
    private float fitnessSum;

    public GeneticAlgorithm(int populationSize, int dnaSize, System.Random random, Func<T> getRandomGene, Func<int, float> fitnessFunction, int elitism, float mutationRate = 0.01f) {
        Generation = 1;
        Elitism = elitism;
        MutationRate = mutationRate;
        Population = new List<DNA<T>>(populationSize);
        newPopulation = new List<DNA<T>>(populationSize);
        this.random = random;

        BestGenes = new T[dnaSize];

        for(int i = 0; i < populationSize; i++) {
            Population.Add(new DNA<T>(dnaSize, random, getRandomGene, fitnessFunction, shouldInitGenes : true));
        }
    }

    public void NewGeneration() {
        // Debug.Log("-----Population count-----");
        // Debug.Log(Population.Count);
        if(Population.Count <= 0) {
            return;
        }

        CalculateFitness();
        Population.Sort(CompareDNA);
        newPopulation.Clear();

        for(int i = 0; i < Population.Count; i++) {
            if( i < Elitism) {
                newPopulation.Add(Population[i]);
            }
            else {
                DNA<T> parent1 = ChooseParent();
                DNA<T> parent2 = ChooseParent();

                DNA<T> child = parent1.Crossover(parent2);

                child.Mutate(MutationRate);
                newPopulation.Add(child);
            }
        }

        // Add one more child each generation
        DNA<T> parent1a = ChooseParent();
        DNA<T> parent2a = ChooseParent();

        DNA<T> childa = parent1a.Crossover(parent2a);

        childa.Mutate(MutationRate);
        newPopulation.Add(childa);

        List<DNA<T>> tmpList = Population;
        Population = newPopulation;
        newPopulation = tmpList;

        Generation++;
    }

    public int CompareDNA(DNA<T> a, DNA<T> b) {
        if(a.Fitness > b.Fitness) {
            return -1;
        }
        else if(a.Fitness < b.Fitness) {
            return 1;
        }
        return 0;
    }

    public void CalculateFitness() {
        fitnessSum = 0;
        DNA<T> best = Population[0];
        for(int i = 0; i < Population.Count; i++) {
            fitnessSum += Population[i].CalculateFitness(i);

            if(Population[i].Fitness > best.Fitness) {
                best = Population[i];
            }
        }

        BestFitness = best.Fitness;
        best.Genes.CopyTo(BestGenes, 0);
    }

    private DNA<T> ChooseParent() {
        double randomNumber = random.NextDouble() * fitnessSum;

        for(int i = 0; i < Population.Count; i++) {
            if(randomNumber < Population[i].Fitness) {
                return Population[i];
            }

            randomNumber -= Population[i].Fitness;
        }

        return null;
    }
}
