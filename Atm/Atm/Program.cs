using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string kullanici; 
            string sifrem;
            int bakiye = 5000;
            int borc = 3000;
            while(true) {
                Console.WriteLine("Bankamıza Hoş Geldiniz!");
                Console.Write("Kullanıcı Adınızı Girniz:");
                kullanici = Console.ReadLine();
                Console.Write("Şifrenizi Giriniz:");
                sifrem = Console.ReadLine();
                Console.Read();
                if (kullanici=="Orhan" && sifrem=="1234")
                {
                    
                    while(true)
                    {
                        Console.WriteLine("İşlemler \n 1.Para Çekme \n 2.Para Yatırma \n " +
                            "3.Para Gönderme \n 4.Borç Yatırma \n 5.Şifre Değiştirme \n 6.Bakiye Sorgulama \n 7.Çıkış Yap");
                        Console.Write("\nİsleminizi Seciniz: ");
                        Console.Read();
                        string islem = Convert.ToString(Console.ReadLine());
                        
                        if (islem == 1.ToString())
                        {
                            while (true)
                            {
                                int tutar;
                                Console.Write("Çekmek istediğiniz tutarı giriniz: ");
                                tutar = Convert.ToInt32(Console.ReadLine());
                                if (tutar <= bakiye)
                                {
                                    string onay;
                                    Console.Write(tutar+ "TL Tutarında para çekme işlemini onaylıyormusun (E/H):");
                                    onay = Convert.ToString(Console.ReadLine());
                                    if (onay == "E")
                                    {
                                        bakiye -= tutar;
                                        Console.WriteLine("Çekilen Tutar "+ tutar);
                                        Console.WriteLine("Kalan Bakiye "+ bakiye);
                                        break;
                                    }
                                    else if(onay == "H") 
                                    { 
                                        Console.WriteLine("İşlem iptal ediliyor!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz işlem tuşu girdiniz!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Bakiyeniz yeterli değil");
                                }
                            }
                        
                        }
                        
                        else if (islem == 2.ToString())
                        {
                            int yatir;
                            Console.Write("Yatırmak istediğiniz tutarı giriniz: ");
                            yatir = Convert.ToInt32(Console.ReadLine());
                            string onay;
                            Console.Write(yatir + "TL Tutarında para yatırma işlemini onaylıyormusun (E/H):");
                            onay = Convert.ToString(Console.ReadLine());
                            if (onay == "E")
                            {
                                bakiye += yatir;
                                Console.WriteLine("Yatırılan Tutar " + yatir);
                                Console.WriteLine("Toplam Bakiye " + bakiye);
                                break;
                            }
                            else if (onay == "H")
                            {
                                Console.WriteLine("İşlem iptal ediliyor!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz işlem tuşu girdiniz!");
                            }
                        
                        }
                        else if (islem == 3.ToString())
                        {
                            while(true)
                            {
                                int gonder;
                                Console.Write("Yatırmak istediğiniz borç miktarını giriniz:");

                                gonder = Convert.ToInt32(Console.ReadLine());
                                if (gonder <=bakiye)
                                {
                                    int hesapNO;
                                    Console.Write("Göndermek istediğiniz hesap numarasını giriniz:");
                                    hesapNO = Convert.ToInt32(Console.ReadLine());
                                    string onay;
                                    Console.Write(hesapNO + " Hesap Numaralı kullanıcıya "+ gonder +" Tl para gönderme işlemini onaylıyormusun (E/H):");
                                    onay = Convert.ToString(Console.ReadLine());
                                    if (onay == "E")
                                    {
                                        bakiye-=gonder;
                                        Console.WriteLine(hesapNO + " Hesap Numaralı kullanıcıya " + gonder + "Tl para gönderildi!");
                                        Console.WriteLine("Kalan Bakiye "+ bakiye);
                                        break;
                                    }
                                    else if (onay == "H")
                                    {
                                        Console.WriteLine("İşlem iptal ediliyor!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Geçersiz işlem tuşu girdiniz!");
                                    }
                                }
                            }
                        
                        }
                        else if (islem == 4.ToString())
                        {
                            if (borc > 0)
                            {
                                Console.WriteLine("Güncel Borcunuz "+ borc);
                                while(true)
                                {
                                    int borcyatir;
                                    Console.Write("Yatırmak istediğiniz borç tutarını giriniz:");
                                    borcyatir = Convert.ToInt32(Console.ReadLine());
                                    if (borcyatir <= bakiye)
                                    {
                                        if (borcyatir <= borc) { 
                                            string onay;
                                            Console.Write(borcyatir+" TL para yatırma işlemini onaylıyormusun (E/H):");
                                            onay = Convert.ToString(Console.ReadLine());
                                            if (onay == "E")
                                            {
                                                borc -= borcyatir;
                                                bakiye-=borcyatir;
                                                Console.WriteLine("Ödenen borç miktarı: " + borcyatir);
                                                Console.WriteLine("Kalan Borcunuz: " + borc);
                                                Console.WriteLine("Kalan Bakiyeniz: "+bakiye);
                                                break;
                                            }
                                            else if (onay == "H")
                                            {
                                                Console.WriteLine("İşlem iptal ediliyor!");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Geçersiz işlem tuşu girdiniz!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Borcunuzdan fazlasını yatırmayın:)");
                                        }
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Bakiyeniz yeterli değil");
                                    }
                                }
                            }
                        
                        }
                        else if (islem == 5.ToString())
                        {
                            int yeniKak = 3;
                            while (true)
                            {
                                string eski;
                                Console.Write("Eski şifrenizi giriniz:");
                                eski = Console.ReadLine();
                                yeniKak -= 1;
                                
                                if (eski == sifrem)
                                {
                                    string yenisifre;
                                    Console.Write("Yeni Şifrenizi Giriniz:");
                                    yenisifre = Console.ReadLine();

                                    sifrem = yenisifre;

                                    Console.WriteLine("Şifreniz Güncellendi");
                                    break;
                                }
                                else if (yeniKak == 0)
                                {
                                    Console.WriteLine("Şifre değiştirme hakkınız bitti");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Hatakı Şifre Girdiniz!");
                                }
                            }
                        
                        }
                        else if (islem  == 6.ToString())
                        {
                            if (bakiye > 0)
                            {
                                Console.WriteLine("Mevcut Bakiyeniz "+bakiye);
                            }
                            else
                            {
                                Console.WriteLine("Bakiyeniz Bulunmuyor!");
                            }
                       
                        }
                        else if (islem == 7.ToString())
                        {
                            Console.WriteLine("Program Kapatılıyor");
                            break;
                        }
                    break;
                    }
                
                }
                else
                {
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı!");
                    break;
                }
            }
        }
        
    }
}
