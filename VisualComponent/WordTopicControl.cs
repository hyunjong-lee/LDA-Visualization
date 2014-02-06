using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Data;
using VisualComponent;
using System.Drawing.Drawing2D;
using Core.Model;

namespace TopicVisualizer
{
    public partial class WordTopicControl: UserControl
    {
        private int _topWordCount = 10;
        private LDAModel _ldaModel;
        private Parameter _parameter;
        private List<List<Tuple<int, double>>> _topicTopWordDist;
        private HashSet<int> _topWordSet;

        public WordTopicControl()
        {
            InitializeComponent();
        }

        public void UpdateTopicModel(LDAModel model, Parameter parameter, int topWordCount = 5)
        {
            _ldaModel = model;
            _parameter = parameter;
            _topWordCount = topWordCount;

            var topicCount = _parameter.TopicCount;

            // extract top words from each topic
            _topicTopWordDist = new List<List<Tuple<int, double>>>(topicCount);
            foreach (var topicId in Enumerable.Range(0, _parameter.TopicCount))
            {
                _topicTopWordDist.Add(
                    model.Phi[topicId]
                        .Select((elem, idx) => new Tuple<int, double>(idx, elem))
                        .OrderByDescending(e => e.Item2)
                        .Take(_topWordCount)
                        .ToList());
            }

            // extract top word set
            _topWordSet = new HashSet<int>(_topicTopWordDist
                .SelectMany(e => e.Select(t => t.Item1))
                .Distinct()
                .OrderBy(e => e));

            // resize
            var startX = 160;
            var startY = 160;

            var len = 30;
            var width = len * (topicCount - 1);
            var height = len * (_topWordSet.Count - 1);

            var totalWidth = startX + width + 50;
            var totalHeight = startY + height + 50;

            Width = totalWidth;
            Height = totalHeight;
        }

        private void WordTopicControl_Paint(object sender, PaintEventArgs e)
        {
            if (_ldaModel == null) return;
            if (_parameter == null) return;
            if (_topWordSet == null) return;

            var topicCount = _parameter.TopicCount;
            var wordCount = _topWordSet.Count;

            const int startX = 160;
            const int startY = 160;

            var len = 30;
            var width = len * (topicCount - 1);
            var height = len * (wordCount - 1);

            const int textBoxWidth = 120;
            const int textBoxHeight = 30;

            var graphic = e.Graphics;
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            var pen = new Pen(Color.FromArgb(236, 236, 236));
            var font = new Font("Malgun Gothic", 10);
            var brush = new SolidBrush(Color.BlueViolet);
            var transBrush = new SolidBrush(Color.FromArgb(120, Color.Red));
            foreach (var topicId in Enumerable.Range(0, topicCount))
            {
                var rect = new Rectangle(startX + topicId * len - len / 2, 10, textBoxHeight, textBoxWidth);

                graphic.DrawRectangle(pen, rect);
                var topicTitle = string.Format("Topic {0}", topicId);
                graphic.DrawString(topicTitle, font, brush, rect,
                    new StringFormat {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                        FormatFlags = StringFormatFlags.DirectionVertical,
                    });
                graphic.DrawLine(pen, startX + topicId * len, startY, startX + topicId * len, startY + height);
            }

            foreach (var wordIdx in Enumerable.Range(0, wordCount))
            {
                var rect = new Rectangle(10, startY + wordIdx * len - 30 / 2, textBoxWidth, textBoxHeight);

                graphic.DrawRectangle(pen, rect);
                var word = _topWordSet.ElementAt(wordIdx).ToWord();
                graphic.DrawString(word, font, brush, rect,
                    new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });

                graphic.DrawLine(pen, startX, startY + wordIdx * len, startX + width, startY + wordIdx * len);
            }

            foreach (var topicId in Enumerable.Range(0, topicCount))
            {
                var topProb = _topicTopWordDist[topicId][0].Item2;
                foreach (var wordIdx in Enumerable.Range(0, wordCount))
                {
                    var x = startX + topicId * len;
                    var y = startY + wordIdx * len;
                    var wordProb =
                        _topicTopWordDist[topicId].FirstOrDefault(elem => elem.Item1 == _topWordSet.ElementAt(wordIdx));
                    var relativeSize = 0;
                    if (wordProb != null) relativeSize = (int) (50*wordProb.Item2/topProb);
                    var rect = new Rectangle(x - relativeSize / 2, y - relativeSize / 2, relativeSize, relativeSize);
                    graphic.DrawEllipse(pen, rect);
                    graphic.FillEllipse(transBrush, rect);
                }
            }

        }

        private void WordTopicControl_MouseHover(object sender, EventArgs e)
        {

        }

        private void WordTopicControl_MouseLeave(object sender, EventArgs e)
        {

        }

        private void WordTopicControl_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void WordTopicControl_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void WordTopicControl_Load(object sender, EventArgs e)
        {

        }
    }
}
