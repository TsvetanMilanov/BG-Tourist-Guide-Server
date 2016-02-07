namespace BGTouristGuide.Services
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using Gma.QrCodeNet.Encoding;

    using Contracts;
    using System.IO;
    using Gma.QrCodeNet.Encoding.Windows.Render;
    using System.Drawing.Imaging;

    public class QrCodeServices : IQrCodeServices
    {
        public void GenerateQrCodesForIds(string directory, IEnumerable<string> items)
        {
            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);

            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

            int index = 0;
            foreach (var item in items)
            {
                QrCode qrCode = encoder.Encode(item);

                using (FileStream stream = new FileStream(string.Format("{0}\\{1}.png", directory, index), FileMode.Create))
                {
                    renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);
                }

                index++;
            }
        }
    }
}
