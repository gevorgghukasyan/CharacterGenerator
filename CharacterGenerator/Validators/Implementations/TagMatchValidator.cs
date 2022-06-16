using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Validators.Implementations
{
	public class TagMatchValidator : IValidator
	{
		private readonly Func<Combination, ImageMetadata> _image1;
		private readonly Func<Combination, ImageMetadata> _image2;

		public TagMatchValidator(Func<Combination, ImageMetadata> image1, Func<Combination, ImageMetadata> image2)
		{
			_image1 = image1;
			_image2 = image2;
		}

		public bool Execute(Combination item)
		{
			var img1 = _image1(item);
			if(img1.Tag == null)
			{
				return true;
			}

			var img2 = _image2(item);
			if(img2.Tag == null)
			{
				return true;
			}

			return img1.Tag == img2.Tag;
		}
	}
}
