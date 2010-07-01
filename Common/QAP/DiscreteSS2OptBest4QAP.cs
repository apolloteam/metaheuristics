using System;

namespace Metaheuristics
{
	public class DiscreteSS2OptBest4QAP : DiscreteSS
	{
		public QAPInstance Instance { get; protected set; }
		
		public DiscreteSS2OptBest4QAP(QAPInstance instance, int poolSize, int refSetSize, double explorationFactor)
			: base(poolSize, refSetSize, explorationFactor)
		{
			Instance = instance;
		}
		
		protected override double Fitness(int[] solution)
		{
			return QAPUtils.Fitness(Instance, solution);
		}
		
		protected override int[] RandomSolution()
		{
			return QAPUtils.RandomSolution(Instance);
		}
		
		protected override void Repair(int[] solution)
		{
			QAPUtils.Repair(Instance, solution);
		}
		
		protected override void Improve (int[] solution)
		{
			QAPUtils.LocalSearch2OptBest(Instance, solution);
		}
		
		protected override double Distance(int[] a, int[] b)
		{
			return QAPUtils.Distance(Instance, a, b);
		}
	}
}
