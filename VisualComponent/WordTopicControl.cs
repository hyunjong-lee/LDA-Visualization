using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;
using Core.Data;

namespace TopicVisualizer
{
    public partial class WordTopicControl: UserControl
    {
        private int TopWordCount = 10;
        private LDAModel LDAModel;
        private List<List<Tuple<int, double>>> TopicTopWordDist;
        private HashSet<int> TopWordSet;

        public WordTopicControl()
        {
            InitializeComponent();
        }

        public void UpdateTopicModel(LDAModel model, int topWordCount = 10)
        {
            LDAModel = model;
            TopWordCount = topWordCount;

            var topicCount = LDAModel.Parameter.TopicCount;

            // extract top words from each topic
            TopicTopWordDist = new List<List<Tuple<int, double>>>(topicCount);
            foreach (var topicId in Enumerable.Range(0, model.Parameter.TopicCount))
            {
                TopicTopWordDist.Add(
                    model.Phi[topicId]
                        .Select((elem, idx) => new Tuple<int, double>(idx, elem))
                        .OrderByDescending(e => e.Item2)
                        .Take(TopWordCount)
                        .ToList());
            }

            // extract top word set
            TopWordSet = new HashSet<int>(TopicTopWordDist
                .SelectMany(e => e.Select(t => t.Item1))
                .Distinct()
                .OrderBy(e => e));

            // resize
            // ???
        }

        private void WordTopicControl_Paint(object sender, PaintEventArgs e)
        {
            var topicCount = 10;
            var wordCount = 50;

            var startX = 100;
            var startY = 50;

            var len = 100;
            var width = len * (topicCount - 1);
            var height = len * (wordCount - 1);

            var graphic = e.Graphics;
            var pen = new Pen(Color.FromArgb(236, 236, 236));
            var font = new Font("Malgun Gothic", 10);
            var brush = new SolidBrush(Color.DimGray);
            foreach (var topicId in Enumerable.Range(0, topicCount))
            {
                var rect = new RectangleF(startX + topicId * len - len / 2, 10, len, 30);
                graphic.DrawString("Topic 0", font, brush, rect,
                    new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center});
                graphic.DrawLine(pen, startX + topicId * len, startY, startX + topicId * len, startY + height);
            }

            foreach (var wordIdx in Enumerable.Range(0, wordCount))
            {
                graphic.DrawLine(pen, startX, startY + wordIdx * len, startX + width, startY + wordIdx * len);
            }
        }
    }
}
