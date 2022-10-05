namespace NeuralNetworks
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();

            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            var sum = 0.0;
            for(int i= 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }
            
            Output = Sigmoid(sum);
            return Output;
        }

        public void SetWeights(params double[] weights)
        {
            // TODO: Delete after adding neural network training.
            for(int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }

        private double Sigmoid(double x)
        {
            var result = 1.0 / (1.0 + Math.Exp(-x));
            return result;
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}