﻿using System.Collections;
using System.Collections.Generic;
using System;

// Kryzarel youtube tutorial
public class DNA<T> {
    public T[] Genes {get; private set;}
    public float Fitness {get; private set;}

    private System.Random random;
    private Func<T> getRandomGene;
    private Func<int, float> fitnessFunction;

    public DNA(int size, System.Random random, Func<T> getRandomGene, Func<int, float> fitnessFunction, bool shouldInitGenes = true) {
        Genes = new T[size];
        this.random = random;
        this.getRandomGene = getRandomGene;
        this.fitnessFunction = fitnessFunction;

        if(shouldInitGenes) {
            for(int i = 0; i < Genes.Length; i++) {
                Genes[i] = getRandomGene();
            }
        }
    }

    public float CalculateFitness(int index) {
        Fitness = fitnessFunction(index);
        return Fitness;
    }

    public DNA<T> Crossover(DNA<T> otherParent) {
        DNA<T> child = new DNA<T>(Genes.Length, random, getRandomGene, fitnessFunction, shouldInitGenes : false);

        for(int i = 0; i < Genes.Length; i++) {
            child.Genes[i] = random.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
        }

        return child;
    }

    public void Mutate(float mutationRate) {
        for(int i = 0; i < Genes.Length; i++) {
            if(random.NextDouble() < mutationRate) {
                Genes[i] = getRandomGene();
            }
        }
    }
}