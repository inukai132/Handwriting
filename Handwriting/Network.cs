using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handwriting
{
    class Network
    {
        Random r { get; set; }
        
        int layers { get; set; }
        List<int> sizes { get; set; }
        List<List<double>> biases { get; set; }
        List<List<double>> weights { get; set; }


        public Network(List<int> _sizes)
        {
            r = new Random(DateTime.Now.Millisecond);
            sizes = _sizes;
            biases = new List<List<double>>();
            weights = new List<List<double>>();
            for (int j = 0; j < sizes.Count; j++ )
            {
                var t = new List<double>();
                for (int i = 0; i < sizes[j]; i++)
                {
                    t.Add(r.NextDouble());
                }
                biases.Add(t);
                if(j+1 != sizes.Count)
                {
                    int x = sizes[j];
                    int y = sizes[j + 1];
                    for (int xi = 0; xi < x; xi++)
                    {
                        var temp = new List<double>();
                        for (int yi = 0; yi < y; yi++)
                        {
                            temp.Add(r.NextDouble());
                        }
                        weights.Add(temp);
                    }
                }
            }
        }

        public double sigmoid(double z)
        {
            return 1.0d / (1.0d + Math.Exp(-z));
        }

        public List<double> sigmoid(List<double> zvec)
        {
            zvec.ForEach( (z) => z = (1.0d / (1.0d + Math.Exp(-z))));
            return zvec;
        }

        //public List<double> feedForward(List<double> a)
        //{
        //    for (int i = 0; i < sizes.Count; i++)
        //    {
        //        a[i] = 
        //    }
        //}
    }
}
