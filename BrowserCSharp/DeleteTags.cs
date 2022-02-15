using System;
using System.Text.RegularExpressions;

class Tags
{
    public static string DeleteAll(string filetext)
    {
        filetext = DeleteScript(filetext);
        filetext = DeleteCSS(filetext);
        filetext = DeleteTags(filetext);
        filetext = DeleteEscape(filetext);
        filetext = DeleteEscapeNum(filetext);
        filetext = DeleteKav(filetext);
        filetext = filetext.Replace("\n", " ");
        filetext = filetext.Replace("\r", " ");
        return filetext;
    }
    public static string DeleteKav(string filetext)
    {
        return filetext.Replace("'","");
    }

    public static string DeleteScript(string filetext)
    {
        String ScriptPattern = "<SCRIPT.*?</SCRIPT>";
        Regex reScript = new Regex(ScriptPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        filetext = reScript.Replace(filetext, " ");
        return filetext;
    }
    public static string DeleteCSS(string filetext)
    {
        String CSSPattern = "<STYLE.*?</STYLE>";
        Regex reCSS = new Regex(CSSPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        filetext = reCSS.Replace(filetext, " ");
        return filetext;
    }
    public static string DeleteTags(string filetext)
    {
        String TagsPattern = "</?(HTML|BODY|A|H1|H2|H3|H4|H5|H6|P|DIV|ADDRESS|BLOCKQUOTE|BR|HR|PRE|LISTING|PLAINTEXT|XMP|BASEFONT|FONT|I|EM|B|STRONG|U|S|STRIKE|BIG|SMALL|SUP|SUB|CODE|SAMP|TT|KBD|VAR|CITE|UL|OL|LI|MENU|DIR|DL|DT|DD|IMG|EMBED|NOEMBED|APPLET|PARAM|TABLE|CAPTION|TR|TD|TH|FORM|TEXTAREA|SELECT|OPTION|INPUT|HEAD|TITLE|BASE|STYLE|LINK|META|FRAMESET|FRAME|NOFRAMES|SCRIPT|NOSCRIPT|MAP|AREA|CENTER|COL|!--|!.{1}ENDIF.{1}--|TBODY|LABEL|WBR|NOBR|FIELDSET|LEGEND|!DOCTYPE).*?>";
        Regex reTags = new Regex(TagsPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        filetext = reTags.Replace(filetext, " ");
        return filetext;

    }
    public static string DeleteEscape(string filetext)
    {
        String EscapePattern = "&(nbsp|iexcl|cent|pound|curren|yen|brvbar|sect|uml|copy|ordf|laquo|not|shy|reg|macr|deg|plusmn|sup2|sup3|acute|micro|para|middot|cedil|sup1|ordm|raquo|frac14|frac12|frac34|iquest|Agrave|Aacute|Acirc|Atilde|Auml|Aring|AElig|Ccedil|Egrave|Eacute|Ecirc|Euml|Igrave|Iacute|Icirc|Iuml|ETH|Ntilde|Ograve|Oacute|Ocirc|Otilde|Ouml|times|Oslash|Ugrave|Uacute|Ucirc|Uuml|Yacute|THORN|szlig|agrave|aacute|acirc|atilde|auml|aring|aelig|ccedil|egrave|eacute|ecirc|euml|igrave|iacute|icirc|iuml|eth|ntilde|ograve|oacute|ocirc|otilde|ouml|divide|oslash|ugrave|uacute|ucirc|uuml|yacute|thorn|yuml|fnof|Alpha|Beta|Gamma|Delta|Epsilon|Zeta|Eta|Theta|Iota|Kappa|Lambda|Mu|Nu|Xi|Omicron|Pi|Rho|Sigma|Tau|Upsilon|Phi|Chi|Psi|Omega|alpha|beta|gamma|delta|epsilon|zeta|eta|theta|iota|kappa|lambda|mu|nu|xi|omicron|pi|rho|sigmaf|sigma|tau|upsilon|phi|chi|psi|omega|thetasym|upsih|piv|bull|hellip|prime|Prime|oline|frasl|weierp|image|real|trade|alefsym|larr|uarr|rarr|darr|harr|crarr|lArr|uArr|rArr|dArr|hArr|forall|part|exist|empty|nabla|isin|notin|ni|prod|sum|minus|lowast|radic|prop|infin|ang|and|or|cap|cup|int|there4|sim|cong|asymp|ne|equiv|le|ge|sub|sup|nsub|sube|supe|oplus|otimes|perp|sdot|lceil|rceil|lfloor|rfloor|lang|rang|loz|spades|clubs|hearts|diams|quot|amp|lt|gt|OElig|oelig|Scaron|scaron|Yuml|circ|tilde|ensp|emsp|thinsp|zwnj|zwj|lrm|rlm|ndash|mdash|lsquo|rsquo|sbquo|ldquo|rdquo|bdquo|dagger|Dagger|permil|lsaquo|rsaquo|euro);";
        Regex reEscape = new Regex(EscapePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        filetext = reEscape.Replace(filetext, " ");
        return filetext;
    }
    public static string DeleteEscapeNum(string filetext)
    {
        String EscapeNumPattern = "&#[0-9]{1,4};";
        Regex reEscapeNum = new Regex(EscapeNumPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        filetext = reEscapeNum.Replace(filetext, " ");


        return filetext;

    }

}