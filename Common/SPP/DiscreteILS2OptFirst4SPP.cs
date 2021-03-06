using System;

namespace Metaheuristics
{
	public class DiscreteILS2OptFirst4SPP : DiscreteILS
	{
		public SPPInstance Instance { get; protected set; }
		
		protected int generatedSolutions;		
		
		public DiscreteILS2OptFirst4SPP (SPPInstance instance, int restartIterations, 
		                                 int[] lowerBounds, int[] upperBounds) 
			: base ( restartIterations, lowerBounds, upperBounds)
		{
			Instance = instance;
			RepairEnabled = false;
			generatedSolutions = 0;			
		}
		
		protected override void LocalSearch(int[] individual)
		{
			SPPUtils.LocalSearch2OptFirst(Instance, individual);
		}		
		
		protected override double Fitness(int[] individual)
		{
			return SPPUtils.Fitness(Instance, individual);
		}
		
		protected override int[] InitialSolution ()
		{
			int[] solution;
			
			if (generatedSolutions < 2) {
				solution = SPPUtils.GRCSolution(Instance, 1.0);
			}
			else {
				solution = SPPUtils.RandomSolution(Instance);
			}
			
			generatedSolutions++;
			return solution;
		}

		protected override void PerturbateSolution (int[] solution, int perturbation)
		{
			SPPUtils.PerturbateSolution(Instance, solution, perturbation);
		}
	}
}