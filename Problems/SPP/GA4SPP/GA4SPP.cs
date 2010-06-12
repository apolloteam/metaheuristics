using System;
using System.Collections.Generic;

namespace Metaheuristics
{
	public class GA4SPP : IMetaheuristic
	{
		public void Start(string fileInput, string fileOutput, int timeLimit)
		{
			SPPInstance instance = new SPPInstance(fileInput);
			
			// Setting the parameters of the GA for this instance of the problem.
			int popSize = 50 * instance.NumberItems;
			double mutProbability = 0.3;
			int[] lowerBounds = new int[instance.NumberItems];
			int[] upperBounds = new int[instance.NumberItems];
			for (int i = 0; i < instance.NumberItems; i++) {
				lowerBounds[i] = 0;
				upperBounds[i] = instance.NumberSubsets - 1;
			}
			DiscreteGA genetic = new DiscreteGA4SPP(instance, popSize, mutProbability, lowerBounds, upperBounds);
			
			// Solving the problem and writing the best solution found.
			genetic.Run(timeLimit);
			SPPSolution solution = new SPPSolution(instance, genetic.BestIndividual);
			solution.Write(fileOutput);
		}
		
		public string Name {
			get {
				return "GA for SPP";
			}
		}
		
		public MetaheuristicType Type {
			get {
				return MetaheuristicType.GA;
			}
		}
		
		public ProblemType Problem {
			get {
				return ProblemType.SPP;
			}
		}
		
		public string[] Team {
			get {
				return About.Team;
			}
		}
	}
}
