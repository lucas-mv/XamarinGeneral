//DependencyService for playing a video from device path

//For Android
public void Play(string path)
{
	var bytes = File.ReadAllBytes(path);

	string externalStorageState = global::Android.OS.Environment.ExternalStorageState;
	string application = "";

	string extension = System.IO.Path.GetExtension(path);

	switch (extension.ToLower())
	{
		case ".mp4":
			application = "video/mp4";
			break;
		case ".flv":
			application = "video/x-flv";
			break;
		case ".m3u8":
			application = "application/x-mpegURL";
			break;
		case ".ts":
			application = "video/MP2T";
			break;
		case ".3gp":
			application = "video/3gpp";
			break;
		case ".mov":
			application = "video/quicktime";
			break;
		case ".avi":
			application = "video/x-msvideo";
			break;
		case ".wmv":
			application = "video/x-ms-wmv";
			break;
		default:
			application = "*/*";
			break;
	}

	Java.IO.File file = new Java.IO.File(path);
	file.SetReadable(true);
	Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
	Intent intent = new Intent(Intent.ActionView);
	intent.SetDataAndType(uri, application);
	intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

	Xamarin.Forms.Forms.Context.StartActivity(intent);
}

//For iOS
public void Play(string path)
{
	var _player = new AVPlayer(NSUrl.FromFilename(path));
	var _playerController = new AVPlayerViewController();
	_playerController.Player = _player;

	var window = UIApplication.SharedApplication.KeyWindow;
	var vc = window.RootViewController;
	while (vc.PresentedViewController != null)
	{
		vc = vc.PresentedViewController;
	}

	vc.PresentViewController(_playerController, true, null);
	_playerController.View.Frame = vc.View.Frame;
}
