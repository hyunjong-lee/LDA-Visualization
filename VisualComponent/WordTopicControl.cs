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
using VisualComponent;
using System.Drawing.Drawing2D;

namespace TopicVisualizer
{
    public partial class WordTopicControl: UserControl
    {
        private int _topWordCount = 10;
        private LDAModel _ldaModel;
        private List<List<Tuple<int, double>>> _topicTopWordDist;
        private HashSet<int> _topWordSet;

        private List<ButtonInfo> _buttonInfoList;

        public WordTopicControl()
        {
            InitializeComponent();
        }

        public void UpdateTopicModel(LDAModel model, int topWordCount = 10)
        {
            _ldaModel = model;
            _topWordCount = topWordCount;

            var topicCount = _ldaModel.Parameter.TopicCount;

            // extract top words from each topic
            _topicTopWordDist = new List<List<Tuple<int, double>>>(topicCount);
            foreach (var topicId in Enumerable.Range(0, model.Parameter.TopicCount))
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
            // ???
        }

        private void WordTopicControl_Paint(object sender, PaintEventArgs e)
        {
            var topicCount = 50;
            var wordCount = 50;

            var startX = 160;
            var startY = 160;

            var len = 40;
            var width = len * (topicCount - 1);
            var height = len * (wordCount - 1);

            var textBoxWidth = 120;
            var textBoxHeight = 30;

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
                graphic.DrawString("Topic 0", font, brush, rect,
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
                graphic.DrawString("Word 0", font, brush, rect,
                    new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });

                graphic.DrawLine(pen, startX, startY + wordIdx * len, startX + width, startY + wordIdx * len);
            }

            foreach (var topicId in Enumerable.Range(0, topicCount))
            {
                foreach (var wordIdx in Enumerable.Range(0, wordCount))
                {
                    var x = startX + topicId * len;
                    var y = startY + wordIdx * len;
                    var rect = new Rectangle(x - 25, y - 25, 50, 50);
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
    }
}
