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

        public const int MOVING_SPEED = 5;
        public PictureBox[] shadows= new PictureBox[4];

        Point[] oldShadowLocations=new Point[4];

        Point[] startingShadowLocations = new Point[4];
        Size wayTaken;

        Point startingPoint;
        public World() {
            InitializeComponent();
            Init();
            control.Start();
        }
        private void Init() {
            shadows[0]=shadow1;
            shadows[1]=shadow2;
            shadows[2]=shadow3;
            shadows[3]=shadow4;
            startingPoint=character.Location;
            for(int i = 0; i<shadows.Length; i++) {
                startingShadowLocations[i]=shadows[i].Location;
            }
        }
      

        private void World_KeyDown(object sender, KeyEventArgs e) {
            for(int i = 0; i<shadows.Length; i++) {
                oldShadowLocations[i]=shadows[i].Location;
            }
            if(e.KeyCode == Keys.Up) {
                wayTaken.Height-=MOVING_SPEED;
            }
            if(e.KeyCode == Keys.Down) {
                wayTaken.Height+=MOVING_SPEED;
            }
            if(e.KeyCode == Keys.Left) {
                wayTaken.Width-=MOVING_SPEED;
            }
            if(e.KeyCode == Keys.Right) {
                wayTaken.Width+=MOVING_SPEED;
            }
            for(int i = 0; i<shadows.Length; i++) {
                shadows[i].Location=Point.Add(shadows[i].Location,wayTaken);
            }
            character.Location = Point.Add(character.Location, wayTaken);
            wayTaken.Width=wayTaken.Height=0;
        }

        private void World_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void Control_Tick(object sender, EventArgs e) {
            if(character.Bounds.IntersectsWith(end.Bounds)) {
                
                DialogResult ds =MessageBox.Show("Do you wanna play again?", "YOU WON!", MessageBoxButtons.YesNo);
                if(ds == DialogResult.No) Application.Exit();

                

            }
            foreach(PictureBox pb in Controls) {
                if(character.Bounds.IntersectsWith(pb.Bounds) && !pb.Equals(character)) {
                    character.Location=startingPoint;
                    for(int i = 0; i<shadows.Length; i++) {
                        shadows[i].Location=startingShadowLocations[i];
                    }
                    break;
                }
            }
        }
    }
}
