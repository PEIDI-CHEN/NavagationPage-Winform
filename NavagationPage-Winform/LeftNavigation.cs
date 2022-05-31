using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NavagationPage_Winform
{
    public partial class LeftNavigation : UserControl
    {
        /// <summary>
        /// 生成菜单按钮的方法，可以自己设置按钮的风格、属性，主要按钮的父类是Control即可
        /// </summary>
        public Func<Control> CreateBtnFunc = () => { return null; };

        /// <summary>
        /// 菜单按钮的点击事件，在处理完导航内容的显示任务后触发
        /// </summary>
        public event EventHandler BtnClick;

        /// <summary>
        /// 获取或设置菜单按钮的背景颜色
        /// </summary>
        public Color BtnBackColor { get; set; } = Color.FromArgb(30, 56, 83);

        /// <summary>
        /// 获取或设置菜单按钮的选中颜色
        /// </summary>
        public Color BtnSelectkColor { get; set; } = Color.FromArgb(67, 92, 200);

        /// <summary>
        /// 获取菜单按钮的大小，这个属性基本上很少变动，所以只支持在构造函数的参数中设置该值
        /// </summary>
        public Size BtnSize { get; }

        /// <summary>
        /// 获取菜单按钮之间、菜单按钮与面板边缘之间的间距，该值也作为拆分器的间隔设定值。
        /// 这个属性基本上很少变动，所以只支持在构造函数的参数中设置该值。
        /// </summary>
        public int BtnInterval { get; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="btnWidth">菜单按钮的宽度</param>
        /// <param name="btnHeight">菜单按钮的高度</param>
        /// <param name="btnInterval">间距值</param>
        public LeftNavigation(int btnWidth = 198, int btnHeight = 66, int btnInterval = 5)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            //用户控件太小时，splitContainer尺寸调整会失效
            this.Size = new Size(1000, 1000);

            BtnSize = new Size(btnWidth, btnHeight);
            BtnInterval = btnInterval;

            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.SplitterWidth = BtnInterval;
            splitContainer1.SplitterDistance = BtnSize.Width + BtnInterval * 2;
            splitContainer1.IsSplitterFixed = true;


            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel2.AutoScroll = true;

            splitContainer1.Panel1.BackColor = Color.White;
        }
        /// <summary>
        /// 菜单按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Control? btnCtr = sender as Control;
            if (splitContainer1.Panel2.Controls.Count > 0 && splitContainer1.Panel2.Controls[0] == (Form)(btnCtr.Tag))
            {
                return;
            }
            foreach (var item in splitContainer1.Panel1.Controls)
            {
                Control btnItem = item as Control;
                Form form = btnItem.Tag as Form;
                if (btnItem == btnCtr)
                {
                    btnItem.BackColor = BtnSelectkColor;
                    splitContainer1.Panel2.Controls.Clear();
                    if (form != null)
                    {
                        splitContainer1.Panel2.Controls.Add(form);
                        form.Visible = true;
                    }
                }
                else
                {
                    btnItem.BackColor = BtnBackColor;
                    if (form != null) form.Visible = false;
                }
            }

            if (BtnClick != null) BtnClick(sender, e);


        }

        /// <summary>
        /// 生成菜单按钮
        /// </summary>
        /// <param name="text">显示的文本</param>
        /// <param name="tag">对应的窗体实例</param>
        /// <param name="point">按钮位置</param>
        /// <returns></returns>
        private Control CreateBtnCtr(string text, Form tag, Point point)
        {
            Control btnCtr = CreateBtnFunc();
            if (btnCtr == null)
            {
                Button btn = new Button();
                btn.BackColor = BtnBackColor;
                btn.Font = new Font("Tahoma", 20, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btnCtr = btn;

            }

            btnCtr.Click += button_Click;
            btnCtr.Text = text;
            btnCtr.Tag = tag;
            btnCtr.Size = BtnSize;
            btnCtr.Location = new Point(point.X, point.Y);

            return btnCtr;
        }

        /// <summary>
        /// 设置导航信息
        /// </summary>
        /// <param name="btnDic"></param>
        public void SetNavigation(Dictionary<string, Form> btnDic)
        {
            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel2.Controls.Clear();

            Point point = new Point(BtnInterval, BtnInterval);
            foreach (var item in btnDic)
            {
                if (item.Value != null)
                {
                    item.Value.TopLevel = false;
                    item.Value.FormBorderStyle = FormBorderStyle.None;
                    item.Value.Dock = DockStyle.Fill;
                    item.Value.AutoScroll = true;
                    item.Value.Show();
                }
                if (!string.IsNullOrEmpty(item.Key))
                {
                    Control btnCtr = CreateBtnCtr(item.Key, item.Value, point);
                    point.Y = point.Y + BtnSize.Height + BtnInterval;
                    splitContainer1.Panel1.Controls.Add(btnCtr);
                }
            }

            if (splitContainer1.Panel1.Controls.Count > 0)
            {
                button_Click(splitContainer1.Panel1.Controls[0], new EventArgs());
            }
        }
    }
}
