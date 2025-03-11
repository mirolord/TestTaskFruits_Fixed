using Zenject;
using UnityEngine;

public class GameInstaller : MonoInstaller
{
	[SerializeField] private CameraControllerPanel _cameraControllerPanel;

	private void Awake()
	{
		if (_cameraControllerPanel == null)
		{
			Debug.LogError("Компонент CameraControllerPanel не назначен.");
		}
	}

	public override void InstallBindings()
	{
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			Container.Bind<IController>().To<MobileController>().AsSingle().WithArguments(_cameraControllerPanel);
			Container.Bind<ISettings>().To<MobileSetting>().AsSingle();
		}
		else
		{
			Container.Bind<IController>().To<DesctopController>().AsSingle();
			Container.Bind<ISettings>().To<DesctopSetting>().AsSingle();
		}
	}
}