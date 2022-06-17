using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace posertrimer
{
    public partial class MainForm : Form
    {
        enum FillMode
        {
            NONE,
            HATCH,
            FILL,
        }

        float degree = 0;
        float size = 700;
        FillMode fillMode = FillMode.NONE;

        ToolForm m_ToolForm = null;

        public MainForm()
        {
            InitializeComponent();

            // ツールフォームの表示
            m_ToolForm = new ToolForm(this);
            m_ToolForm.Show(this);

            TopMost = true;
            BackColor = Color.Blue; // 枠線色
            Padding = new Padding(1); // 枠線幅
            //FormBorderStyle = FormBorderStyle.None;

            updateView();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            if (pictureBox1 == null)
                return;

            updateView();
        }

        private void updateView()
        {
            if (pictureBox1.Width < 10 || pictureBox1.Height < 10)
                return;

            if (pictureBox1.Image == null
             || (pictureBox1.Image.Width != pictureBox1.Width || pictureBox1.Image.Height != pictureBox1.Height))
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            SizeF size = new SizeF(16, 9);

            float len = (float)Math.Sqrt(size.Width * size.Width + size.Height * size.Height);
            SizeF norm = new SizeF(size.Width / len, size.Height / len);

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                PointF[] pointFs = new PointF[8];
                pointFs[0] = new PointF(+norm.Width * this.size, +norm.Height * this.size);
                pointFs[1] = new PointF(+norm.Width * this.size, -norm.Height * this.size);

                pointFs[2] = new PointF(0, -norm.Height * this.size);
                pointFs[3] = new PointF(0, -norm.Height * this.size * 1.1f);
                pointFs[4] = new PointF(0, -norm.Height * this.size);

                pointFs[5] = new PointF(-norm.Width * this.size, -norm.Height * this.size);
                pointFs[6] = new PointF(-norm.Width * this.size, +norm.Height * this.size);
                pointFs[7] = pointFs[0];

                float rad = degree / 180.0f * (float)Math.PI;
                float cos = (float)Math.Cos(rad);
                float sin = (float)Math.Sin(rad);

                for (int i = 0; i < pointFs.Length; i++)
                {
                    pointFs[i] = new PointF(pictureBox1.Width / 2 + pointFs[i].X * cos - pointFs[i].Y * sin, pictureBox1.Height / 2 + pointFs[i].X * sin + pointFs[i].Y * cos);
                }

                switch (fillMode)
                {
                    case FillMode.NONE:
                    default:
                        g.Clear(Color.Fuchsia);
                        g.DrawLines(Pens.Blue, pointFs);
                        break;
                    case FillMode.FILL:
                        g.Clear(Color.DarkGray);
                        g.FillPolygon(Brushes.Fuchsia, pointFs);
                        g.DrawLines(Pens.Blue, pointFs);
                        break;
                    case FillMode.HATCH:
                        {
                            //HatchBrushオブジェクトの作成
                            HatchBrush myBrush = new HatchBrush(HatchStyle.Percent50, Color.Fuchsia, Color.DarkGray);
                            //四角を塗りつぶす
                            g.FillRectangle(myBrush, pictureBox1.Bounds);
                        }
                        g.FillPolygon(Brushes.Fuchsia, pointFs);
                        g.DrawLines(Pens.Blue, pointFs);
                        break;
                }

            }

            pictureBox1.Invalidate();

            this.Text = "EasyPoseTrimer - " + this.size.ToString("0") + "/" + this.degree.ToString("0");
        }

        public void scaleUp()
        {
            size += (Control.ModifierKeys.HasFlag(Keys.Control) ? 200 : 50);
            updateView();
        }

        public void scaleDown()
        {
            size -= (Control.ModifierKeys.HasFlag(Keys.Control) ? 200 : 50);
            updateView();
        }

        public void rotCounterClockwise()
        {
            degree -= (Control.ModifierKeys.HasFlag(Keys.Control) ? 20 : 5);
            updateView();
        }

        public void rotClockwise()
        {
            degree += (Control.ModifierKeys.HasFlag(Keys.Control) ? 20 : 5);
            updateView();
        }

        public void changeFillMode()
        {
            switch (fillMode)
            {
                case FillMode.NONE:
                    fillMode = FillMode.HATCH;
                    break;
                case FillMode.HATCH:
                    fillMode = FillMode.FILL;
                    break;
                case FillMode.FILL:
                    fillMode = FillMode.NONE;
                    break;
                default:
                    fillMode = FillMode.NONE;
                    break;
            }
            updateView();
        }

        public void capture()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(PointToScreen(new Point(pictureBox1.Left, pictureBox1.Top)), new Point(0, 0), bitmap.Size);
            }

            Bitmap toImage = new Bitmap(2560, 1440);

            SizeF size = new SizeF(16, 9);

            float len = (float)Math.Sqrt(size.Width * size.Width + size.Height * size.Height);
            SizeF norm = new SizeF(size.Width / len, size.Height / len);

            using (Graphics g = Graphics.FromImage(toImage))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;

                PointF[] pointFs = new PointF[5];
                pointFs[0] = new PointF(+norm.Width * this.size, +norm.Height * this.size);
                pointFs[1] = new PointF(+norm.Width * this.size, -norm.Height * this.size);
                pointFs[2] = new PointF(-norm.Width * this.size, -norm.Height * this.size);
                pointFs[3] = new PointF(-norm.Width * this.size, +norm.Height * this.size);
                pointFs[4] = pointFs[0];

                float rad = degree / 180.0f * (float)Math.PI;
                float cos = (float)Math.Cos(rad);
                float sin = (float)Math.Sin(rad);

                for (int i = 0; i < pointFs.Length; i++)
                {
                    pointFs[i] = new PointF(pictureBox1.Width / 2 + pointFs[i].X * cos - pointFs[i].Y * sin, pictureBox1.Height / 2 + pointFs[i].X * sin + pointFs[i].Y * cos);
                }

                float scale = (float)Math.Sqrt(toImage.Width * toImage.Width + toImage.Height * toImage.Height) / (this.size * 2);

                g.ResetTransform();
                g.TranslateTransform(-bitmap.Width / 2, -bitmap.Height / 2, MatrixOrder.Append);
                g.ScaleTransform(scale, scale, MatrixOrder.Append);
                g.RotateTransform(-degree, MatrixOrder.Append);
                g.TranslateTransform(toImage.Width / 2, toImage.Height / 2, MatrixOrder.Append);

                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            }

            Clipboard.SetImage(toImage);

            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                //SaveFileDialogクラスのインスタンスを作成
                SaveFileDialog sfd = new SaveFileDialog();

                //はじめのファイル名を指定する
                //はじめに「ファイル名」で表示される文字列を指定する
                sfd.FileName = "idea_000.jpg";
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                sfd.Filter = "JPGファイル(*.jpeg;*.jpg)|*.jpeg;*.jpg|すべてのファイル(*.*)|*.*";
                //タイトルを設定する
                sfd.Title = "保存先のファイルを選択してください";
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                sfd.RestoreDirectory = true;

                //ダイアログを表示する
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    toImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        static bool dummy()
        {
            return false;
        }

        Image CreateThumb(Image baseImage, int width, int height)
        {
            return baseImage.GetThumbnailImage(width, height, new Image.GetThumbnailImageAbort(dummy), IntPtr.Zero);
        }
    }
}
