using System;

namespace Metaheuristics
{
	public class DiscreteGA4TSP: DiscreteGA
	{
		public TSPInstance Instance { get; protected set; }
		
		public DiscreteGA4TSP(TSPInstance instance, int popSize, double mutationProbability,
		                      int[] lowerBounds, int[] upperBounds)
			: base(popSize, mutationProbability, lowerBounds, upperBounds)
		{
			Instance = instance;
			RepairEnabled = true;
		}
		
		protected override void Repair(int[] individual)
		{
			TSPUtils.Repair(Instance, individual);
		}
		
		protected override double Fitness(int[] individual)
		{
			return TSPUtils.Fitness(Instance, individual);
		}
	}
}
