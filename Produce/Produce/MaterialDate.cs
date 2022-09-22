using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Produce;
using DevExpress.XtraEditors.Design;
using DevExpress.XtraPrinting.BarCode;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ErrorCorrectionLevel = ZXing.QrCode.Internal.ErrorCorrectionLevel;

namespace Produce
{
    public partial class MaterialDate : DevExpress.XtraEditors.XtraForm
    {

        
        public MaterialDate()
        {
            InitializeComponent();
            
        }


        private void productCloseBtn_Click(object sender, EventArgs e)
        {
           this.Close();      
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            BarcodeWriter qrcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions()
            {
                Width = 200,
                Height = 80,
                Margin = 0,
                PureBarcode = false,
                GS1Format = true
            };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            qrcodeWriter.Renderer = new BitmapRenderer();
            qrcodeWriter.Format = BarcodeFormat.CODE_128;
            qrcodeWriter.Options = encodingOptions;
            Bitmap bitmap = qrcodeWriter.Write(barcodeTxt.Text);
            Graphics g = Graphics.FromImage(bitmap);
            barcodePic.Image = bitmap;
        }

        private void clerBtn_Click(object sender, EventArgs e)
        {
            barcodePic.Image = null;
            barcodeTxt.Text = null;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (barcodePic.Image == null)
                return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Png |*. png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    barcodePic.Image.Save(saveFileDialog.FileName);
            }
        }
    }
}