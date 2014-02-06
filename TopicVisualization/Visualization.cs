using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Data;
using Core.Model;
using Core.Helper;

namespace TopicVisualization
{
    public partial class Visualization : Form
    {
        public Visualization()
        {
            InitializeComponent();
        }

        private void Visualization_Load(object sender, EventArgs e)
        {
            var modelPath = @"D:\Model";
            var ldaModel = modelPath.Import<LDAModel>();
            var parameter = modelPath.Import<Parameter>();
            ModelHelper.ImportVoca(modelPath);
            wordTopicControl1.UpdateTopicModel(ldaModel, parameter);
        }
    }
}
