using System.Net;
using System.Text.RegularExpressions;

public class PageRank
{
    public static int GetYandexTCY(string oldurl)
    {
        if (InternetChecker.Check() == "Не обнаружено подключения к интернету")
        {
            return 0;
        }
        if (!oldurl.StartsWith("http://"))
            return 0;
        if (oldurl.Length == 0)
            return 0;
        string xml = "";
        string url = oldurl;
        if (oldurl.Length > 8)
        {
            int i = oldurl.IndexOf('/', 8);
            if (i != -1)
                url = url.Substring(0, i);
        }
        try
        {
            System.Net.WebRequest req =
                System.Net.WebRequest.Create("http://bar-navig.yandex.ru/u?ver=2&show=32&url=" + url);
            System.Net.WebResponse resp = req.GetResponse();

            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            xml = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            resp.Close();
            
            int ind = xml.IndexOf("value=\"");
            if (ind == -1)
                return 0;

            xml = xml.Substring(ind + 7, xml.Length - ind - 7);
            int ind1 = xml.IndexOf('\"');
            if (ind1 == -1)
                return 0;
            xml = xml.Substring(0, ind1);

        }
        catch (System.ArgumentNullException)
        {
            return 0;
        }
        catch (System.NotImplementedException)
        {
            return 0;
        }
        catch (System.Security.SecurityException)
        {
            return 0;
        }
        catch (System.Net.WebException)
        {
            return 0;
        }

        int ret = 0;
        try
        {
            ret = int.Parse(xml);
        }
        catch (System.ArgumentException)
        {
            return 0;
        }
        catch (System.OverflowException)
        {
            return 0;
        }
        catch (System.FormatException)
        {
            return 0;
        }
        return ret;
    }

    public static int GetGooglePageRank(string url)
    {
        if (InternetChecker.Check() == "Не обнаружено подключения к интернету")
        {
            return 0;
        }
        if (!url.StartsWith("http://"))
            return 0;
        if (url.Length == 0)
            return 0;

        url = "info:" + url;
        uint checksum = GetChecksum(url.ToCharArray());
        checksum = GoogleNewCh(checksum);
        string googleUrl = "http://toolbarqueries.google.com/search?client=navclient-auto&ch=6" + checksum
            + "&ie=UTF-8&oe=UTF-8&features=Rank:FVN&q=" + url;

        string pageText = GetResponseText(googleUrl);

        string pageRankString = "0";
        Regex re = new Regex("Rank_.*?:.*?:(?<1>\\d+)\\n", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        Match m = re.Match(pageText);
        if (m.Success) pageRankString = m.Groups[1].ToString();

        int pageRank = int.Parse(pageRankString);
        return pageRank;
    }

    private static uint GetChecksum(char[] url)
    {
        uint a = 0x9E3779B9;
        uint b = a;
        uint c = 0xE6359A60;
        int k = 0;
        int len = url.Length;

        while (len >= 12)
        {
            a += ((uint) url[k + 0] + ((uint) url[k + 1] << 8) + ((uint) url[k + 2] << 16) + ((uint) url[k + 3] << 24));
            b += ((uint) url[k + 4] + ((uint) url[k + 5] << 8) + ((uint) url[k + 6] << 16) + ((uint) url[k + 7] << 24));
            c += ((uint) url[k + 8] + ((uint) url[k + 9] << 8) + ((uint) url[k + 10] << 16) + ((uint) url[k + 11] << 24));

            uint[] mix = Mix(a, b, c);
            a = mix[0];
            b = mix[1];
            c = mix[2];
            k += 12;
            len -= 12;
        }
        c += (uint)url.Length;

        switch (len)
        {
            case 11: c += ((uint) url[k + 10] << 24); goto case 10;
            case 10: c += ((uint) url[k + 9] << 16); goto case 9;
            case 9: c += ((uint) url[k + 8] << 8); goto case 8;
            case 8: b += ((uint) url[k + 7] << 24); goto case 7;
            case 7: b += ((uint) url[k + 6] << 16); goto case 6;
            case 6: b += ((uint) url[k + 5] << 8); goto case 5;
            case 5: b += ((uint) url[k + 4]); goto case 4;
            case 4: a += ((uint) url[k + 3] << 24); goto case 3;
            case 3: a += ((uint) url[k + 2] << 16); goto case 2;
            case 2: a += ((uint) url[k + 1] << 8); goto case 1;
            case 1: a += ((uint) url[k + 0]); break;
        }

        uint[] mixx = Mix(a, b, c);
        return (uint) mixx[2];
    }

    private static char[] c32to8bit(uint[] arr32) 
    {
        char[] arr8 = new char[4 * arr32.Length];
        for (int i=0; i<arr32.Length; i++)
        {
            for (int bitOrder=i*4; bitOrder<=i*4+3; bitOrder++)
            {
                arr8[bitOrder] = (char)(arr32[i] & 255);
                arr32[i] = ZeroFill(arr32[i], 8);
            }
        }
        return arr8;
    }

    private static uint myfmod(uint x, int y)
    {
        int i = (int)System.Math.Floor((decimal)x / y);
        return (uint)(x - i * y);
    }

    private static uint GoogleNewCh(uint ch)
    {
        ch = (((ch/7) << 2) | ((myfmod(ch, 13))&7));
        uint[] prbuf = new uint[20];
        prbuf[0] = ch;
        for(int i = 1; i < 20; i++)
        {
            prbuf[i] = prbuf[i-1]-9;
        }
        ch = GetChecksum(c32to8bit(prbuf));
        return ch;
    }

    private static uint[] Mix(uint a, uint b, uint c)
    {
        a -= b; a -= c; a = a ^ (ZeroFill(c, 13));
        b -= c; b -= a; b ^= a << 8;
        c -= a; c -= b; c = c ^ (ZeroFill(b, 13));
        a -= b; a -= c; a = a ^ (ZeroFill(c, 12));
        b -= c; b -= a; b ^= a << 16;
        c -= a; c -= b; c = c ^ (ZeroFill(b, 5));
        a -= b; a -= c; a = a ^ (ZeroFill(c, 3));
        b -= c; b -= a; b ^= a << 10;
        c -= a; c -= b; c = c ^ (ZeroFill(b, 15));

        uint[] arr = new uint[3];
        arr[0] = a;
        arr[1] = b;
        arr[2] = c;
        return arr;
    }

    private static uint ZeroFill(uint a, int b)
    {
        uint z = 0x80000000;
        if ((z & a) > 0)
        {
            a = a >> 1;
            a = a & (~z);
            a = a | 0x40000000;
            a = a >> (b - 1);
        }
        else
            a = a >> b;
        return a;
    }

    private static string GetResponseText(string url)
    {
        string pageText = "";

        HttpWebRequest request = null;
        WebResponse response = null;
        System.IO.Stream stream = null;
        System.IO.StreamReader reader = null;
        try
        {
            request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent = "Mozilla/4.0 (compatible; GoogleToolbar 2.0.114-big; Windows XP 5.1)";
            request.Timeout = 4 * 1000;

            response = request.GetResponse();

            stream = response.GetResponseStream();
            reader = new System.IO.StreamReader(
                stream, System.Text.Encoding.GetEncoding(1251));
            pageText = reader.ReadToEnd();
        }
        catch (WebException)
        {
        }
        finally
        {
            if (response != null) response.Close();
            if (stream != null) stream.Close();
            if (reader != null) reader.Close();
        }
        return pageText;
    }
}
