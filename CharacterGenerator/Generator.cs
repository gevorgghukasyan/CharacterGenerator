using CharacterGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterGenerator.Extensions;
namespace CharacterGenerator
{
	public class Generator
	{
		public static string GetId(ImageMetadata imageMetadata)
		{
			return imageMetadata.Id;
		}

		public static void Generate(Combination combination, string targetFolder)
		{
			//var aa = new[] { new { a = 7 }, new { a = 7 } };
			var imgs = new[]
			{
				new { pf="bg", img = combination.Background.Image(), id = GetId(combination.Background) },
				new { pf="wp", img = combination.Weapon.Image(), id = GetId(combination.Weapon) },
				new { pf="ps", img = combination.Person.Image(), id = GetId(combination.Person) },
				new { pf="ey", img = combination.Eye.Image(), id = GetId(combination.Eye) },
				new { pf="ar", img = combination.Armour.Image(), id = GetId(combination.Armour) },
				new { pf="am", img = combination.Amulet.Image(), id = GetId(combination.Amulet) },
				new { pf="pi", img = combination.Piercing.Image(), id = GetId(combination.Piercing)},
				new { pf="ha", img = combination.Hat.Image(), id = GetId(combination.Hat)},
				new { pf="mo", img = combination.Mouth.Image(), id = GetId(combination.Mouth)},
			};
			var name = string.Join(" ", imgs.Select(x => $"{x.pf}_{x.id}"));
			Generate(imgs.Select(x => x.img), targetFolder, name);
		}
		public static void Generate(IEnumerable<Image> images, string targetFolder, string name)
		{
			var all = images.ToList();
			//(all[0])
			//var bitmap = (Bitmap)all[0];
			using (var bitmap = (Bitmap)(all[0].Clone()))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					for (int i = 1; i < all.Count; i++)
					{
						if (all[i] != null)
						{
							graphics.DrawImage(all[i], 0, 0);
						}
					}
					//graphics.SmoothingMode = SmoothingMode.HighQuality;
					//graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
					//graphics.CompositingQuality = CompositingQuality.HighQuality;
					//graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					//graphics.SmoothingMode = SmoothingMode.hi;
					//graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
					//graphics.CompositingQuality = CompositingQuality.HighQuality;
					//graphics.PixelOffsetMode = PixelOffsetMode.;
					Extensions.Extensions.Save(bitmap, targetFolder, name);
				}
			}
		}
	}
}