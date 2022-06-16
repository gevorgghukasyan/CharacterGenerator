using CharacterGenerator.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGenerator.Entities
{
	public class ImageMetadata
	{
		public string ImagePath;
		public string Id { get; set; }
		public string Tag { get; set; }
		public string RootFolderName { get; set; }

		//public string Name { get; set; }

		public ImageMetadata(string image, string id, string rootFolderName, string tag)
		{
			ImagePath = image;
			Id = id;
			RootFolderName = rootFolderName;
			Tag = tag;
		}

		public Image Image() => GetByPath(ImagePath);

        public override bool Equals(object obj)
        {
			var item = obj as ImageMetadata;

			if (item == null)
			{
				return false;
			}

			return this.Id.Equals(item.Id);
		}


		static Dictionary<string, Image> _images = new Dictionary<string, Image>();

		static Image GetByPath(string path)
        {
			if(path == null)
            {
				return null;
            }
			if(_images.TryGetValue(path, out Image image))
            {
				return image;
            }

			image = path.ImageFromFile().ResizeImage(new Size(500, 500));
			_images.Add(path, image);
			return image;
        }
    }
}
