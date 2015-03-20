using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public static class ImageCache
    {
        static Dictionary<string, ImageSource> cache = new Dictionary<string, ImageSource>();
        public static ImageSource GetImageFromFileName(String filename)
        {
            ImageSource retVal = null;
            bool hit = cache.TryGetValue(filename, out retVal);

            if (!hit)
            {
                retVal = ImageSource.FromFile(filename);
                cache[filename] = retVal;
            }
            return retVal;
        }
    }
}
