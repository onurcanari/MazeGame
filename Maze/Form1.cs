using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze {
    public partial class World : Form {

        public const int MOVING_SPEED = 40;

        Point newPoint;
        
        public World() {
            InitializeComponent();
        }
        
      

        private void World_KeyDown(object sender, KeyEventArgs e) {
            
            newPoint = character.Location;

            if(e.KeyCode == Keys.Up) {
                
                newPoint.Y-=MOVING_SPEED;
            }
            if(e.KeyCode == Keys.Down) {
                newPoint.Y+=MOVING_SPEED;
            }
            if(e.KeyCode == Keys.Left) {
                newPoint.X-=MOVING_SPEED;
            }
            if(e.KeyCode == Keys.Right) {
                newPoint.X+=MOVING_SPEED;
            }
            
            character.Location = newPoint;
        }

        private void World_KeyPress(object sender, KeyPressEventArgs e) {

        }
    }
}
