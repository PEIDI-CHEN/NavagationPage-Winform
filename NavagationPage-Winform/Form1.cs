using Timer = System.Windows.Forms.Timer;

namespace NavagationPage_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LeftNavigation leftNavigation = new LeftNavigation();
            Dictionary<string, Form> btnFormDic = new Dictionary<string, Form>()
            {
                {"form1",new Form2()},
                {"form2",new Form3()},
                {"form3",new Form4()},
                {"�˳�",null}
            };

            leftNavigation.SetNavigation(btnFormDic);
            leftNavigation.BtnClick += (sender, e) =>
            {
                Control ctr = sender as Control;
                if (ctr.Text == "�˳�")
                {
                    this.Close();
                }
            };

            panel_Navigation.Controls.Add(leftNavigation);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = SystemColors.ActiveCaption;
            panel_Title.MouseDown += windowMove_MouseDown;
            panel_Title.MouseUp += windowMove_MouseUp;
            panel_Title.MouseMove += windowMove_MouseMove;
            panel_Title.MouseDoubleClick += windowMove_DoubleClick;
            label_Title.AutoSize = true;
            label_Title.Anchor = AnchorStyles.None;
            label_Title.Location = new Point((panel_Title.Size.Width - label_Title.Size.Width) / 2, (panel_Title.Size.Height - label_Title.Size.Height) / 2);
            label_Title.Text = "Page Title";
            #region
            //get the time for the bottom panel
            label_Time.Text = DateTime.Now.ToString();
            label_Time.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, obj) =>
            {
                label_Time.Text = DateTime.Now.ToString();
            };
            timer.Start();
            #endregion
            panel_Title.Dock = DockStyle.Top;
            panel_Navigation.Dock = DockStyle.Fill;
            panel_State.Dock = DockStyle.Bottom;
            //�������ڶ���
            panel_Navigation.BringToFront();

        }
        #region �ޱ߿����ƶ������

        // ��갴��
        private bool isMouse = false; // ����Ƿ���
                                      // ԭ��λ��
        private int originX = 0;
        private int originY = 0;
        // ��갴��λ��
        private int mouseX = 0;
        private int mouseY = 0;
        private void windowMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { // �ж���갴��
                isMouse = true;
                // ��Ļ����λ��
                originX = this.Location.X;
                originY = this.Location.Y;
                // ��갴��λ��
                mouseX = originX + e.X;
                mouseY = originY + e.Y;
            }
        }

        // ����ƶ�
        private void windowMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouse)
            {
                // �ƶ�����
                int moveX = (e.X + this.Location.X) - mouseX;
                int moveY = (e.Y + this.Location.Y) - mouseY;
                int targetX = originX + moveX;
                int targetY = originY + moveY;
                this.Location = new Point(targetX, targetY);
            }
        }

        // ����ͷ�
        private void windowMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouse)
            {
                isMouse = false;
            }
        }

        // ���˫��
        private void windowMove_DoubleClick(object sender, MouseEventArgs e)
        {
            if (isMouse)
            {
                this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            }
        }

        #endregion
    }
}