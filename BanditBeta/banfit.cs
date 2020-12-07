using System;
namespace BanditUCB
{
  class BanditProgram
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Begin UCB1 bandit demo \n");
      Console.WriteLine("Three arms with true means u1 = " +
       "0.3, u2 = 0.7, u3 = 0.5");
      Random rnd = new Random(20);
      int N = 3;
      int trials = 6;
      double p = 0.0;
      double[] means = new double[] { 0.3, 0.7, 0.5 };
      double[] cumReward = new double[N];
      int[] armCounts = new int[N];
      double[] avgReward = new double[N];
      double[] decValues = new double[N];
      // Play each arm once to get started
      Console.WriteLine("Playing each arm once: ");
      for (int i = 0; i < N; ++i) {
        Console.Write("[" + i + "]: ");
        p = rnd.NextDouble();
        if (p < means[i]) {
          Console.WriteLine("win");
          cumReward[i] += 1.0;
        }
        else {
          Console.WriteLine("lose");
          cumReward[i] += 0.0;
        }
        ++armCounts[i];
      }
      Console.WriteLine("-------------");
      for (int t = 1; t <= trials; ++t) {
        Console.WriteLine("trial #" + t);
        Console.Write("curr cum reward: ");
        for (int i = 0; i < N; ++i)
          Console.Write(cumReward[i].ToString("F2") + " ");
        Console.Write("\ncurr arm counts: ");
        for (int i = 0; i < N; ++i)
          Console.Write(armCounts[i] + " ");
        Console.Write("\ncurr avg reward: ");
        for (int i = 0; i < N; ++i) {
          avgReward[i] = (cumReward[i] * 1.0) / armCounts[i];
          Console.Write(avgReward[i].ToString("F2") + " ");
        }
        Console.Write("\ndecision values: ");
        for (int i = 0; i < N; ++i) {
          decValues[i] = avgReward[i] +
            Math.Sqrt( (2.0 * Math.Log(t) / armCounts[i]) );
          Console.Write(decValues[i].ToString("F2") + " ");
        }
        int selected = ArgMax(decValues);
        Console.WriteLine("\nSelected machine = [" +
          selected + "]");
        p = rnd.NextDouble();
        if (p < means[selected]) {
          cumReward[selected] += 1.0;
          Console.WriteLine("result: a WIN");
        }
        else {
          cumReward[selected] += 0.0;
          Console.WriteLine("result: a LOSS");
        }
        ++armCounts[selected];
        Console.WriteLine("-------------");
      } // t
      Console.WriteLine("End bandit UCB1 demo ");
      Console.ReadLine();
    } // Main
    static int ArgMax(double[] vector)
    {
      double maxVal = vector[0];
      int result = 0;
      for (int i = 0; i < vector.Length; ++i) {
        if (vector[i] > maxVal) {
          maxVal = vector[i];
          result = i;
        }
      }
      return result;
    }
  } // Program
} // ns