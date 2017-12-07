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
    }
}
