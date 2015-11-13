using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handwriting
{
    public static class LoaderMNist
    {
        private static string trainingImagesName = "train-images.idx3-ubyte";
        private static string trainingLabelsName = "train-labels.idx1-ubyte";
        private static string testingImagesName = "t10k-images.idx3-ubyte";
        private static string testingLabelsName = "t10k-labels.idx1-ubyte";
        
        public static List<ImageMNist> getTrainingData()
        {
            List<string> labels;
            using(var fs = new FileStream(Path.Combine(new string[]{".","images",trainingLabelsName}), FileMode.Open))
            {
                var buf = new byte[(int)fs.Length];
                fs.Read(buf, 0, (int)fs.Length);
                var lab = ByteToHexArray(buf);

                int magicNum = Convert.ToInt32(
                    lab.Dequeue() + lab.Dequeue() +
                    lab.Dequeue() + lab.Dequeue(), 16);

                int numItems = Convert.ToInt32(
                    lab.Dequeue() + lab.Dequeue() +
                    lab.Dequeue() + lab.Dequeue(), 16);

                labels = lab.ToList<string>();
                labels = labels.ConvertAll((s) => s = s[1].ToString());
            }

            List<string> images;
            int numRows, numCols;
            using (var fs = new FileStream(Path.Combine(new string[] { ".", "images", trainingImagesName }), FileMode.Open))
            {
                var buf = new byte[(int)fs.Length];
                fs.Read(buf, 0, (int)fs.Length);
                var img = ByteToHexArray(buf);

                int magicNum = Convert.ToInt32(
                    img.Dequeue() + img.Dequeue() +
                    img.Dequeue() + img.Dequeue(), 16);

                int numItems = Convert.ToInt32(
                    img.Dequeue() + img.Dequeue() +
                    img.Dequeue() + img.Dequeue(), 16);

                numRows = Convert.ToInt32(
                    img.Dequeue() + img.Dequeue() +
                    img.Dequeue() + img.Dequeue(), 16);

                numCols = Convert.ToInt32(
                    img.Dequeue() + img.Dequeue() +
                    img.Dequeue() + img.Dequeue(), 16);

                images = img.ToList<string>();
                images.ForEach((s) => s = s.TrimStart('0'));
            } 

            return new List<ImageMNist>();
        }

        public static Queue<string> ByteToHexArray(byte[] byteArray)
        {
            var q = new Queue<string>();
            foreach (var number in byteArray)
            {
                q.Enqueue(Convert.ToString(number, 16).PadLeft(2,'0'));
            }
            return q;
        }
    }

    public class ImageMNist
    {
        int rows, cols;
        List<int> data;
        string label;
        public ImageMNist(){}
        public ImageMNist(int _rows, int _cols, List<int> _data, string _label = "")
        {
            rows = _rows;
            cols = _cols;
            data = _data;
            label = _label;
        }
    }
}
