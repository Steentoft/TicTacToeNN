using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ONeuralNetwork
{
    //By Christian Steentoft
    public class ONeuralNetwork
    {
        int[] layers;
        float[][] neurons;
        float[][][] weights;

        float fitness;
        public ONeuralNetwork(int[] layers)
        {
            this.layers = layers;

            InitializeNeurons();
            InitializeFirstWeights();
        }

        void InitializeNeurons()
        {
            List<float[]> neuronRow = new List<float[]>();
            for (int i = 0; i < layers.Length; i++)
            {
                neuronRow.Add(new float[layers[i]]);
            }
            neurons = neuronRow.ToArray();
        }
        void InitializeFirstWeights()
        {
            //OuterList
            List<float[][]> weightList = new List<float[][]>();
            for (int i = 1; i < layers.Length; i++)
            {
                //MiddleList
                List<float[]> layerWeightList = new List<float[]>();
                int neuronInLastLayer = layers[i - 1];
                for (int j = 0; j < neurons[i].Length; j++)
                {
                    //InnerWeights
                    float[] neuronWeights = new float[neuronInLastLayer];
                    for (int k = 0; k < neuronInLastLayer; k++)
                    {
                        neuronWeights[k] = (float)GetRandomNumber(-0.5, 0.5);
                    }
                    //Adds InnerWeights to MiddleList
                    layerWeightList.Add(neuronWeights);

                }
                //Adds MiddleList to OuterList
                weightList.Add(layerWeightList.ToArray());

            }
            //Adds OuterList to actual weights
            weights = weightList.ToArray();

        }
        public float[] FeedForward(float[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                neurons[0][i] = inputs[i];
            }

            for (int i = 1; i < layers.Length; i++)
            {
                for (int j = 0; j < neurons[i].Length; j++)
                {
                    float value = 0f;

                    for (int k = 0; k < neurons[i - 1].Length; k++)
                    {
                        value += weights[i - 1][j][k] * neurons[i - 1][k];
                    }

                    neurons[i][j] = (float)Math.Tanh(value);
                }
            }

            return neurons[neurons.Length - 1];
        }
        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public float GetFitness()
        {
            return fitness;
        }
        public void AddFitness(float score)
        {
            fitness += score;
        }

        public void Mutate()
        {
            Random rand = new Random();
            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j < weights[i].Length; j++)
                {
                    for (int k = 0; k < weights[i][j].Length; k++)
                    {
                        int value = rand.Next(0, 100);
                        if (value < 10)
                        {
                            weights[i][j][k] = weights[i][j][k] * (float)GetRandomNumber(-0.50, 0.50);
                        }
                    }
                }
            }
        }
    }
}
