using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Fonts;
using System.IO;
using System.Reflection;
using PdfSharpCore.Fonts;
using System.IO;
using IFontResolver = PdfSharp.Fonts.IFontResolver;

namespace Infarstuructre.BL
{
    public class CustomFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            // تحديد المسار للخطوط داخل wwwroot/fonts
            string fontPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fonts", faceName + ".ttf");

            // التأكد من وجود الخط في المجلد
            if (File.Exists(fontPath))
            {
                return File.ReadAllBytes(fontPath);  // إرجاع محتويات الخط إذا تم العثور عليه
            }

            return null;  // في حال لم يتم العثور على الخط
        }

        public string[] GetNames()
        {
            // إعادة أسماء الخطوط المتوفرة
            return new string[] { "TraditionalArabic" };  // تأكد من أن هذا الاسم يتطابق مع اسم الملف
        }

        public PdfSharp.Fonts.FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
        {
            throw new NotImplementedException();
        }

        public string DefaultFontName => "TraditionalArabic";  // استبدال بالاسم المناسب للخط الافتراضي
    }
}
