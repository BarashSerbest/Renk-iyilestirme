using System;
using System.Drawing;

class RenkIyilestirmeAlgoritmasi
{
    static void Main()
    {
        // Görüntüyü yükleme
        Bitmap resim = new Bitmap(@"giris_resmi.jpg"); // Bu kısımda çift tırnaklar arasına iyileştirme yapılmak istenen resimin dosya yolu girilecek. 

        // Renk tonlama
        int ortalamaRenk = OrtalamaRenk(resim);
        int enKaranlikRenk = EnKaranlikRenk(resim);
        int enAcikRenk = EnAcikRenk(resim);
        int aralik = enAcikRenk - enKaranlikRenk;
        double katsayi = 255.0 / aralik;

        // Renk doygunluğu
        for (int x = 0; x < resim.Width; x++)
        {
            for (int y = 0; y < resim.Height; y++)
            {
                Color renk = resim.GetPixel(x, y);
                int kirmizi = (int)((renk.R - ortalamaRenk) * katsayi + ortalamaRenk);
                int yesil = (int)((renk.G - ortalamaRenk) * katsayi + ortalamaRenk);
                int mavi = (int)((renk.B - ortalamaRenk) * katsayi + ortalamaRenk);
                resim.SetPixel(x, y, Color.FromArgb(kirmizi, yesil, mavi));
            }
        }

        // Renk dengesi
        for (int x = 0; x < resim.Width; x++)
        {
            for (int y = 0; y < resim.Height; y++)
            {
                Color renk = resim.GetPixel(x, y);
                int kirmizi = renk.R;
                int yesil = renk.G;
                int mavi = renk.B;
                int maks = Math.Max(Math.Max(kirmizi, yesil), mavi);
                int min = Math.Min(Math.Min(kirmizi, yesil), mavi);
                int aralik2 = maks - min;
                if (aralik2 != 0)
                {
                    if (maks == kirmizi)
                    {
                        kirmizi = (int)((kirmizi - yesil - mavi) / (double)aralik2 * 255.0);
                    }
                    else if (maks == yesil)
                    {
                        yesil = (int)((yesil - kirmizi - mavi) / (double)aralik2 * 255.0);
                    }
                    else
                    {
                        mavi = (int)((mavi - kirmizi - yesil) / (double)aralik2 * 255.0);
                    }
                    resim.SetPixel(x, y, Color.FromArgb(kirmizi, yesil, mavi));
                }
            }
        }
        // Sonuçları kaydetme
        resim.Save(@"cikis_resmi.jpg"); // Bu kısımda iyileştirilmiş resmin çıktısının kaydolmasını istediğimiz dosyanın yolunu girilecek.

    }

    // Ortalama renk hesaplama
    private static int OrtalamaRenk(Bitmap resim)
    {
        int toplamKirmizi = 0;
        int toplamYesil = 0;
        int toplamMavi = 0;
        int pikselSayisi = resim.Width * resim.Height;

        for (int x = 0; x < resim.Width; x++)
        {
            for (int y = 0; y < resim.Height; y++)
            {
                Color renk = resim.GetPixel(x, y);
                toplamKirmizi += renk.R;
                toplamYesil += renk.G;
                toplamMavi += renk.B;
            }
        }

        int ortalamaKirmizi = toplamKirmizi / pikselSayisi;
        int ortalamaYesil = toplamYesil / pikselSayisi;
        int ortalamaMavi = toplamMavi / pikselSayisi;
        int ortalamaRenk = (ortalamaKirmizi + ortalamaYesil + ortalamaMavi) / 3;

        return ortalamaRenk;
    }
    // En karanlık renk hesaplama
    private static int EnKaranlikRenk(Bitmap resim)
    {
        int enKaranlikRenk = 255;
        for (int x = 0; x < resim.Width; x++)
        {
            for (int y = 0; y < resim.Height; y++)
            {
                Color renk = resim.GetPixel(x, y);
                int kirmizi = renk.R;
                int yesil = renk.G;
                int mavi = renk.B;
                int enKucukRenk = Math.Min(Math.Min(kirmizi, yesil), mavi);
                if (enKucukRenk < enKaranlikRenk)
                {
                    enKaranlikRenk = enKucukRenk;
                }
            }
        }
        return enKaranlikRenk;
    }
    // En açık renk hesaplama
    private static int EnAcikRenk(Bitmap resim)
    {
        int enAcikRenk = 0;
        for (int x = 0; x < resim.Width; x++)
        {
            for (int y = 0; y < resim.Height; y++)
            {
                Color renk = resim.GetPixel(x, y);
                int kirmizi = renk.R;
                int yesil = renk.G;
                int mavi = renk.B;
                int enBuyukRenk = Math.Max(Math.Max(kirmizi, yesil), mavi);
                if (enBuyukRenk > enAcikRenk)
                {
                    enAcikRenk = enBuyukRenk;
                }
            }
        }
        return enAcikRenk;
    }

}
