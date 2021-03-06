using System;
using System.Collections.Generic;

using Metaheuristics;

namespace Tune
{
	public class MATuner : Tuner
	{
		public MATuner(ITunableMetaheuristic metaheuristic, string dirInstances)
			: base(metaheuristic, dirInstances, 6, new int[] { 10000 }, 5)
		{
		}
		
		protected override IEnumerable<double[]> EnumerateParameters()
		{
            double[] timePenalties = new double[] { 250, 500 };
			List<double> popSize = new List<double>();
//			popSize.Add(50);
//			popSize.Add(40);
//	        popSize.Add(30);
//			popSize.Add(20);
//			popSize.Add(16);
			popSize.Add(10);
			popSize.Add(8);
			popSize.Add(6);
//			popSize.Add(4);
//			popSize.Add(2);
			double[] mutProbabilities = new double[] { 0.2, 0.3 };
			
			foreach (double timePenalty in timePenalties) {
				foreach (double mutProbability in mutProbabilities) {
					foreach (double popFactor in popSize) {
						yield return new double[] { timePenalty, popFactor, mutProbability };
					}
				}
			}
		}
	}
}
