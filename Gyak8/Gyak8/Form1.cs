using Gyak8.Abstractions;
using Gyak8.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gyak8
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();

        public IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add((Toy)toy);
            toy.Left = -toy.Width;
            panel1.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                panel1.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }
    }
}
