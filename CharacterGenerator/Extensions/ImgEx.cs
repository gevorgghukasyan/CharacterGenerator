using CharacterGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Extensions
{
	internal static class ImgEx
	{
		public static ImageMetadata ZIndex(this ImageMetadata imageMetadata, int index)
		{
			return imageMetadata.Apply(im => im.ZIndex = index);
		}
	}
}
