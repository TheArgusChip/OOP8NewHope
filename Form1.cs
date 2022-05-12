using OOP8.Model;

namespace OOP8
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private ComboBox[] _comboBoxes;
        private Drawer _drawer;
        private RadioButton[] _radioButtons;
        private RadioButton[] _radioButtons2;
        private FiguresHIstory _figugeshistory;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _graphics = Canvas.CreateGraphics();
            _comboBoxes = new ComboBox[] { lineColor, backColor, fillColor };
            
            dGVHistory.ColumnCount = 2;

            var colorFiller = new ColorFiller(_comboBoxes);

            colorFiller.Work();

            _radioButtons = new RadioButton[]
            {
                radioButton1,
                radioButton2,
                radioButton3,
            };

            _radioButtons2 = new RadioButton[]
            {
                radioButton4,
                radioButton5,
            };

            _figugeshistory = new FiguresHIstory(this);
            _drawer = new Drawer(_graphics, _figugeshistory);
        }

        private void backColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            var color = (Color) box.SelectedItem;
            Canvas.BackColor = color;
            _figugeshistory.Draw();
        }

        private void lineColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            _drawer.SetPenColor(box.SelectedItem);
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            _drawer.DoOption(e.Location);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFigureType(sender);
        }

        private void UpdateFigureType(object sender)
        {
            var radio = (RadioButton)sender;

            var index = Array.IndexOf(_radioButtons, radio);
            _drawer.SetFigure(index);
        }

        private void fillColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;

            _drawer.SetBrush(box.SelectedItem);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            var index = Array.IndexOf(_radioButtons2, (RadioButton)sender);
            _drawer.SetOption(index);
        }

        public void UpdateHistory()
        {
            dGVHistory.Rows.Clear();

            var info = _figugeshistory.Drawings;
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Type.ToString() == "Линия")
                {
                    dGVHistory.Rows.Add(info[i].Type.ToString(), info[i].PenColor.ToString());
                    continue;
                }
                dGVHistory.Rows.Add(info[i].Type.ToString(), info[i].BrushColor.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGVHistory.SelectedRows.Count; i++)
            {
                var index = dGVHistory.SelectedRows[i].Index;
                _figugeshistory.Remove(index);
            }
            Canvas.BackColor = (Color)backColor.SelectedItem;
            _figugeshistory.Draw();
        }
    }
}