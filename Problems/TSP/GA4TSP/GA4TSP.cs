using System;
using System.Collections.Generic;

namespace Metaheuristics
{
	public class GA4TSP : IMetaheuristic
	{
		public void Start(string fileInput, string fileOutput, int timeLimit)
		{
			TSPInstance instance = new TSPInstance(fileInput);
			
			// Setting the parameters of the GA for this instance of the problem.
			int popSize = 50 * instance.NumberCities;
			double mutProbability = 0.3;
			int[] lowerBounds = new int[instance.NumberCities];
			int[] upperBounds = new int[instance.NumberCities];
			for (int i = 0; i < instance.NumberCities; i++) {
				lowerBounds[i] = 0;
				upperBounds[i] = instance.NumberCities - 1;
			}
			DiscreteGA genetic = new DiscreteGA4TSP(instance, popSize, mutProbability, lowerBounds, upperBounds);
			
			// Solving the problem and writing the best solution found.
			genetic.Run(timeLimit);
			TSPSolution solution = new TSPSolution(instance, genetic.BestIndividual);
			solution.Write(fileOutput);
		}

		public string Name {
			get {
				return "GA for TSP";
			}
		}
		
		public MetaheuristicType Type {
			get {
				return MetaheuristicType.GA;
			}
		}
		
		public ProblemType Problem {
			get {
				return ProblemType.TSP;
			}
		}
		
		public string[] Team {
			get {
				return About.Team;
			}
		}
	}
}
