using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class Constants
    {
        public const string MAP_STR = "<html><head><style>*{{background-color:#EAECEF;}}iframe{{width:100%;height:100%;overflow:hidden;margin:0 auto;display:block;}}</style></head><body><iframe src=\"{0}\" frameborder=\"0\" scrolling=\"no\"></iframe></body></html>";
        public const string QUOTATION_STR = "<html><head><style>*{{background-color:#EAECEF;}}p{{display:block;}}blockquote{{font-size:18px;font-style:italic;margin:0.25em 0;padding:0.35em 40px;line-height:1.45;position:relative;color:#383838;}}blockquote:before{{display:block;padding-left:10px;content:\"\\201C\";font-size:80px;position:absolute;left:-20px;top:-20px;color:#7a7a7a;}}</style></head><body><blockquote>{0}</blockquote><p>-- {1}</p></body></html>";
        public const string PEOPLE_BTN_STR = "<html><head><style>*{{margin:0;padding:0;}}body{{background-color:rgba(255,255,255,0);}}#img-container{{width:150px;height:150px;position:relative;margin:0 auto;}}#header-container{{background-color:rgba(35,108,168,.6);position:absolute;border-radius:50%;text-align:center;display:table;height:115px;width:115px;bottom:-25%;right:-25%}}img{{border-radius:50%}}h3{{display:table-cell;vertical-align:middle;text-align:center;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;color:white}}</style></head><body><div id=\"img-container\"><img src=\"{0}\" height=\"150\" width=\"auto\"/><div id=\"header-container\"><h3>{1}</h3></div></div></body></html>";
    }
}
