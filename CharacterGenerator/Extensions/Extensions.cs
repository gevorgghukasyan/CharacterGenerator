using CharacterGenerator.Entities;
using CharacterGenerator.Validators.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CharacterGenerator.Extensions
{
	public static class Extensions
	{
		private static int _savedCount;
		public static void Save(this Bitmap bitmap, string path, string name = null, ImageFormat format = null)
		{
			_savedCount++;
			format = format == null ? ImageFormat.Png : format;
			bitmap.Save(Path.Combine(path, $"{name ?? _savedCount.ToString()}.png"), format);
		}

		public static void SaveSmall(this Bitmap bitmap, string path, ImageFormat format = null)
		{
			_savedCount++;
			format = format == null ? ImageFormat.Png : format;

			//bitmap.Save(Path.Combine(path, $"{_savedCount}.png"), format);
			//var a = ImageCodecInfo.GetImageEncoders();
			//return;
			ImageCodecInfo jgpEncoder = ImageCodecInfo.GetImageEncoders().First(e => e.FormatDescription == "PNG");// GetEncoder(ImageFormat.Jpeg);
																												   // Create an Encoder object based on the GUID
																												   // for the Quality parameter category.
			System.Drawing.Imaging.Encoder myEncoder =
				System.Drawing.Imaging.Encoder.Quality;
			// Create an EncoderParameters object.
			// An EncoderParameters object has an array of EncoderParameter
			// objects. In this case, there is only one
			// EncoderParameter object in the array.
			EncoderParameters myEncoderParameters = new EncoderParameters(1);
			EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder,
				50L);
			myEncoderParameters.Param[0] = myEncoderParameter;
			bitmap.Save(Path.Combine(path, $"{_savedCount}_TestPhotoQualityFifty.png"), jgpEncoder,
				myEncoderParameters);
			myEncoderParameter = new EncoderParameter(myEncoder, 100L);
			myEncoderParameters.Param[0] = myEncoderParameter;
			bitmap.Save(Path.Combine(path, $"{_savedCount}_TestPhotoQualityHundred.png"), jgpEncoder,
				myEncoderParameters);
			// Save the bitmap as a JPG file with zero quality level compression.
			myEncoderParameter = new EncoderParameter(myEncoder, 0L);
			myEncoderParameters.Param[0] = myEncoderParameter;
			bitmap.Save(Path.Combine(path, $"{_savedCount}_TestPhotoQualityZero.png"), jgpEncoder,
				myEncoderParameters);
		}

		public static Image ResizeImage(this System.Drawing.Image imgToResize, Size size)
		{
			if(imgToResize == null)
            {
				return null;
            }
			//Get the image current width
			int sourceWidth = imgToResize.Width;
			//Get the image current height
			int sourceHeight = imgToResize.Height;
			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;
			//Calulate  width with new desired size
			nPercentW = ((float)size.Width / (float)sourceWidth);
			//Calculate height with new desired size
			nPercentH = ((float)size.Height / (float)sourceHeight);
			if (nPercentH < nPercentW)
				nPercent = nPercentH;
			else
				nPercent = nPercentW;
			//New Width
			int destWidth = (int)(sourceWidth * nPercent);
			//New Height
			int destHeight = (int)(sourceHeight * nPercent);
			Bitmap b = new Bitmap(destWidth, destHeight);
			Graphics g = Graphics.FromImage((System.Drawing.Image)b);
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			// Draw image with new width and height
			g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
			g.Dispose();
			return (System.Drawing.Image)b;
		}

		static Random random = new Random();
		public static T RandomPickUp<T>(this List<T> collection) where T : ImageMetadata
		{
			var randomIndex = random.Next(0, collection.Count);
			//Type t = collection.GetType();
			//PropertyInfo prop = t.GetProperty("Capacity");
			//var list = prop.GetValue(collection);
			Console.WriteLine($"Randomly got image index : {randomIndex}");
			return collection[randomIndex];
			//return CheckImageValidation(randomImage)
			//	? randomImage
			//	: RandomPickUp<T>(collection.Where(x => x.Id != randomImage.Id));
		}
		static int count = 500000;
		public static IEnumerable<T> RandomPickUp<T>(this IEnumerable<IEnumerable<T>> collection) where T : ImageMetadata
		{
			var randomIndex = random.Next(0, count--);
			//Type t = collection.GetType();
			//PropertyInfo prop = t.GetProperty("Capacity");
			//var list = prop.GetValue(collection);
			Console.WriteLine($"Randomly got image index : {randomIndex}");
			return collection.ElementAt(randomIndex);
			//return CheckImageValidation(randomImage)
			//	? randomImage
			//	: RandomPickUp<T>(collection.Where(x => x.Id != randomImage.Id));
		}
		private static bool CheckImageValidation<T>(T t) where T : ImageMetadata
		{
			//return t.Capacity != 0;
			return true;
		}
		private static void RemoveWithoutCapacityItems<T>(ref IEnumerable<T> collections) where T : ImageMetadata
		{
			//collections.Where(x => x.Capacity > 0);
		}
		public static Image ImageFromFile(this string path)
		{
			if(path == null)
            {
				return null;
            }
			//if (path.IsValidPath())
			//	throw new ArgumentException($"Path is not valid: {nameof(path)}: {path}");
			//if (path.IsNullOrWhiteSpace())
			//	throw new ArgumentNullException(nameof(path));
			return Image.FromFile($"{path}");
		}
		public static bool IsNullOrWhiteSpace(this string str)
		{
			return string.IsNullOrWhiteSpace(str);
		}
		public static List<IValidator> Next(this List<IValidator> validators, IValidator validator)
		{
			validators.Add(validator);
			return validators;
		}
		public static List<IValidator> Next(this IValidator validator, IValidator nextValidator)
		{
			return new List<IValidator> { validator }.Next(nextValidator);
		}
		public static string JoinString(this IEnumerable<string> source, string separator)
		{
			return string.Join(separator, source);
		}
		public static IEnumerable<IEnumerable<Image>> GetImages(this IEnumerable<IEnumerable<ImageMetadata>> imageMetadatas) //where T2 : ImageMetadata
		{
			//var ss = imageMetadatas.ElementAt(0).ToList();
			return imageMetadatas
				.Select(x => x.Select(y => y.Image()));
		}
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			//source.ForEach(action);
			foreach (T element in source)
			{
				action(element);
			}
		}
		public static string GetLastFolderName(this string path)
		{
			return new DirectoryInfo(path).Name;
		}
		public static string GetFileName(this string path)
		{
			return Path.GetFileNameWithoutExtension(path);
		}
		public static string GetDirectoryName(this string path)
		{
			return Path.GetDirectoryName(path);
		}
		public static string GetTag(this string path)
		{
			var tag = path
				.GetFileName()
				.GetDirectoryName()?
				.Split('_');
			return tag?.Length == 2 ? tag[1] : null;
		}
		public static bool IsValidPath(this string path, bool allowRelativePaths = false)
		{
			bool isValid = true;
			try
			{
				string fullPath = Path.GetFullPath(path);
				if (allowRelativePaths)
				{
					isValid = Path.IsPathRooted(path);
				}
				else
				{
					string root = Path.GetPathRoot(path);
					isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
				}
			}
			catch
			{
				isValid = false;
			}
			return isValid;
		}

		public static void WriteToFile<T>(this T t, string path)
		{
			string json = JsonConvert.SerializeObject(t);
			File.WriteAllText(path, json);
		}

		public static T ReadFromFile<T>(this string path)
		{
			var json = File.ReadAllText(path);
			T obj = JsonConvert.DeserializeObject<T>(json);
			return obj;
		}
	}
}