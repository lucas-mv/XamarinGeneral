//DependencyService for getting image byte[] from internal path

//For Android
public byte[] ByteArrayFromStream(string path)
{
	var bitmap = BitmapFactory.DecodeFile(path);
	
	byte[] bitmapData;
	using(stream = new MemoryStream())
	{
		bitmap.Compress(Bitmap.CompressFormat.Png, 50, stream);
		bitmapData = stream.ToArray();
	}
	
	return bitmapData;
}

//For iOS
public byte[] ByteArrayFromStream(string path)
{
	UIImage originalImage = UIImage.FromFile(path);
	return originalImage.AsPNG().ToArray();
}
