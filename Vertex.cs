using System;
using System.Drawing;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Vertex
{
    public int id;
    public float x;
    public float y;
    public Color clr;
    public string url;
    public string name;
    public string text;
    public Vertex()
    {
        id = 0;
        x = 0;
        y = 0;
        clr = Color.Black;
        url = "";
        name = "";
        text = "";
    }
    public Vertex(int id1, float x1, float y1, Color clr1, string url1, string name1, string text1)
    {
        id = id1;
        x = x1;
        y = y1;
        clr = clr1;
        url = url1;
        name = name1;
        text = text1;
    }
    public Vertex(int id1)
    {
        id = id1;
        x = 0;
        y = 0;
        clr = Color.Black;
        url = "";
        name = "";
        text = "";
    }
    public Vertex(int id1, string url1)
    {
        id = id1;
        x = 0;
        y = 0;
        clr = Color.Black;
        url = url1;
        name = "";
        text = "";
    }
    public Vertex(int id1, string url1, string name1, string text1)
    {
        id = id1;
        url = url1;
        name = name1;
        text = text1;
    }
    public bool isMain()
    {
            String dotDomain = "\\.(ru|org|com|net|info|uk)/?$";
            Regex dD = new Regex(dotDomain, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            MatchCollection mc = dD.Matches(url);
            if (mc.Count != 0)//если это главная страница
                return true;
            return false;
            }
    public string getSite()
    {
        string site = url.Substring(7, url.Length - 7);//без http://
        int ind = site.IndexOf("/");
        if (ind == -1)
            return site;
        return site.Substring(0, ind);
    }
}
